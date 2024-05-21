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
    public class FoodCategoryManager : IFoodCategoryService
    {
        private readonly IFoodCategoryDal _foodCategoryDal;
        private readonly IValidator<FoodCategory> _Validator;
        public FoodCategoryManager(IFoodCategoryDal foodCategoryDal, IValidator<FoodCategory> validator)
        {
            _foodCategoryDal = foodCategoryDal;
            _Validator = validator;
        }
        public IResult Add(FoodCategoryCreateDto dto)
        {
            var model = FoodCategoryCreateDto.ToFoodCategory(dto);
            var validator=_Validator.Validate(model);

            string errorMessage = "";
            foreach(var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }
            if(!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _foodCategoryDal.Add(model);

            return new SuccessResult(Uimessage.ADD_MESSAGE);
        }
        public IResult Update(FoodCategoryUpdateDto dto)
        {
            var model = FoodCategoryUpdateDto.ToFoodCategory(dto);

            model.LastUpdatedDate = DateTime.Now;
            _foodCategoryDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);

        }

        public IResult Delete(int id)
        {
            var data=GetById(id).Data;
            var model =FoodCategoryDeleteDto.ToFoodCategory(data);
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
                FoodCategoryDto dto = new FoodCategoryDto
                {
                   Id=model.ID,
                   Name=model.Name,
                   IconName=model.IconName,
                };
                aboutDtos.Add(dto);
            }

            return new SuccessDataResult<List<FoodCategoryDto>>(aboutDtos);
        }

        public IDataResult<FoodCategoryUpdateDto> GetById(int id)
        {
            var model = _foodCategoryDal.GetById(id);
            var foodUpdateDto = FoodCategoryUpdateDto.ToFood(model);
            return new SuccessDataResult<FoodCategoryUpdateDto>(foodUpdateDto);
        }

       
    }
}
