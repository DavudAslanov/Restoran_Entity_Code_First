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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bussines.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;
        private readonly IValidator<Food> _Validator;

        public FoodManager(IFoodDal foodDal, IValidator<Food> validator)
        {
            _foodDal = foodDal;
            _Validator = validator;
        }

        public IResult Add(FoodCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = FoodCreateDto.ToFood(dto);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl,webRootPath);
            if (photoUrl == null || photoUrl.Length == 0)
            {
                var erors = new List<ValidationErrorModel>();
                erors.Add(new ValidationErrorModel { ErrorMessage = Uimessage.PHOTO_SELECTED });
                return new ErrorResult(erors.ValidationErrorMessagesWithNewLine());
            }


            var validator = ValidationTool.Validate(new FoodValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _foodDal.Add(model);
            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(FoodUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = FoodUpdateDto.ToFood(dto);
            var value = GetById(dto.ID).Data;
            model.LastUpdatedDate = DateTime.Now;
            if (photoUrl == null)
            {
                model.PhotoUrl = value.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
            var validator = ValidationTool.Validate(new FoodValidation(), model, out List<ValidationErrorModel> errors);
            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }
            _foodDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _foodDal.Update(data);

            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

       

        public IDataResult<Food> GetById(int id)
        {
            var model = _foodDal.GetById(id);

            return new SuccessDataResult<Food>(model);
        }

        public IDataResult<List<FoodDto>> GetFoodWithFoodCategories()
        {
            return new SuccessDataResult<List<FoodDto>>(_foodDal.GetFoodWithFoodCategories());
        }

        
    }
}
