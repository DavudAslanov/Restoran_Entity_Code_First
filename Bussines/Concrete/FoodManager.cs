using Bussines.Abstract;
using Bussines.BaseEntities;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
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

        public IResult Add(FoodCreateDto dto,IFormFile photoUrl, string webRootPath)
        {
            var model = FoodCreateDto.ToFood(dto);

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            var validator = _Validator.Validate(model);
            List<string> errorMessages = new List<string>();
            foreach (var item in validator.Errors)
            {
                errorMessages.Add(item.ErrorMessage);
            }
            if (!validator.IsValid)
            {
                string erorMessage = string.Join(", ", errorMessages);
                return new ErrorResult(erorMessage);
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
            var validator = _Validator.Validate(model);
            List<string> errorMessages = new List<string>();
            foreach (var item in validator.Errors)
            {
                errorMessages.Add(item.ErrorMessage);
            }
            if (!validator.IsValid)
            {
                string erorMessage = string.Join(", ", errorMessages);
                return new ErrorResult(erorMessage);
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
