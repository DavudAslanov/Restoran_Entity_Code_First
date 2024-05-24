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

namespace Bussines.Concrete
{
    public class FoodCategoryManager : IFoodCategoryService
    {
        private readonly IFoodCategoryDal _foodCategoryDal;
        private readonly IValidator<FoodCategory> _Validator;
        public FoodCategoryManager(IFoodCategoryDal foodCategoryDal, IValidator<FoodCategory> validator)
        {
            _foodCategoryDal = foodCategoryDal;
            _Validator = validator;
        }
        public IResult Add(FoodCategoryCreateDto dto, IFormFile IconName, string webRootPath)
        {
            var model = FoodCategoryCreateDto.ToFoodCategory(dto);

            model.IconName = PictureHelper.UploadImage(IconName, webRootPath);

            var validator=_Validator.Validate(model);
            
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
            _foodCategoryDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(FoodCategoryUpdateDto dto, IFormFile IconName, string webRootPath)
        {
            var model = FoodCategoryUpdateDto.ToFoodCategory(dto);
            var value = GetById(dto.ID).Data;
            if (IconName == null)
            {
                model.IconName = value.IconName;
            }
            else
            {
                model.IconName = PictureHelper.UploadImage(IconName, webRootPath);
            }
            model.LastUpdatedDate = DateTime.Now;
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
            _foodCategoryDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);

        }

        public IResult Delete(int id)
        {
            var model=GetById(id).Data;
            model.Deleted = id;


            _foodCategoryDal.Update(model);
             return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

        public IDataResult<List<FoodCategoryDto>> GetAllFoodCategories()
        {
            var models = _foodCategoryDal.GetAll(x=>x.Deleted==0);
            List<FoodCategoryDto> aboutDtos = new List<FoodCategoryDto>();

            foreach (var model in models)
            {
                FoodCategoryDto dto = new FoodCategoryDto()
                {
                   Id=model.ID,
                   Name=model.Name,
                   IconName=model.IconName,
                };
                aboutDtos.Add(dto);
            }

            return new SuccessDataResult<List<FoodCategoryDto>>(aboutDtos);
        }

        public IDataResult<FoodCategory> GetById(int id)
        {
            var model = _foodCategoryDal.GetById(id);

            return new SuccessDataResult<FoodCategory>(model);
        }

       
    }
}
