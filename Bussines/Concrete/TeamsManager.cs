using Bussines.Abstract;
using Bussines.BaseEntities;
using Bussines.Validations;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Bussines.Concrete
{
    public class TeamsManager : ITeamsService
    {

        private readonly ITeamDal _team;
        private readonly IValidator<Team> _Validator;
        public TeamsManager(ITeamDal teamDal, IValidator<Team> validator)
        {
            _team = teamDal;
            _Validator = validator;
        }
        public IResult Add(TeamsCreateDto dto, IFormFile PhotoUrl, string webRootPath)
        {
            var model = TeamsCreateDto.ToTeams(dto);

            if (PhotoUrl == null || PhotoUrl.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = Uimessage.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }
            model.PhotoUrl = PictureHelper.UploadImage(PhotoUrl, webRootPath);

            var validator = ValidationTool.Validate(new TeamValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _team.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(TeamsUpdateDto dto, IFormFile PhotoUrl, string webRootPath)
        {
            var model = TeamsUpdateDto.ToTeams(dto);

            model.LastUpdatedDate = DateTime.Now;

            var value = GetById(dto.ID).Data;
            model.LastUpdatedDate = DateTime.Now;
            if (PhotoUrl == null)
            {
                model.PhotoUrl = value.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(PhotoUrl, webRootPath);
            }

            var validator = ValidationTool.Validate(new TeamValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _team.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var model = GetById(id).Data;

            model.Deleted = id;

            _team.Update(model);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<Team> GetById(int id)
        {
            var model = _team.GetById(id);

            return new SuccessDataResult<Team>(model);
        }

        public IDataResult<List<TeamsDto>> GetTeamWithTeamCategories()
        {
            return new SuccessDataResult<List<TeamsDto>>(_team.GetTeamWithTeamCategories());
        }

      
    }
}
