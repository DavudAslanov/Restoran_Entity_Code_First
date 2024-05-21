using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAcess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;

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
        public IResult Add(TeamsCreateDto dto)
        {
            var model = TeamsCreateDto.ToTeams(dto);
            var validator = _Validator.Validate(model);

            string errorMessage = "";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }
            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _team.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(TeamsUpdateDto dto)
        {
            var model = TeamsUpdateDto.ToTeams(dto);
            model.LastUpdatedDate = DateTime.Now;
            _team.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var model = GetById(id).Data;
            var teamDelete = TeamsDeleteDto.ToTeams(model);
            teamDelete.Deleted = id;

            _team.Update(teamDelete);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<TeamsUpdateDto> GetById(int id)
        {
            var model = _team.GetById(id);

            var teamUpdate = TeamsUpdateDto.ToTeams(model);

            return new SuccessDataResult<TeamsUpdateDto>(teamUpdate);
        }

        public IDataResult<List<TeamsDto>> GetTeamWithTeamCategories()
        {
            return new SuccessDataResult<List<TeamsDto>>(_team.GetTeamWithTeamCategories());
        }

      
    }
}
