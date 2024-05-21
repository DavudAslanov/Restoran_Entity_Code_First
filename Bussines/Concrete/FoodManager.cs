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
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;
        private readonly IValidator<Food> _Validator;

        public FoodManager(IFoodDal foodDal, IValidator<Food> validator)
        {
            _foodDal = foodDal;
            _Validator = validator;
        }

        public IResult Add(FoodCreateDto dto)
        {
            var model = FoodCreateDto.ToFood(dto);

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
        public IResult Update(FoodUpdateDto dto)
        {
            var model= FoodUpdateDto.ToFood( dto);
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
            _foodDal.Update(model);

            return new SuccessResult(Uimessage.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            var foodDelete = FoodDeleteDto.ToFood(data);
            foodDelete.Deleted = id;

            _foodDal.Update(foodDelete);
            return new SuccessResult(Uimessage.DELETED_MESSAGE);
        }

       

        public IDataResult<FoodUpdateDto> GetById(int id)
        {
            var model = _foodDal.GetById(id);
            var foodUpdateDto = FoodUpdateDto.ToFood(model);

            return new SuccessDataResult<FoodUpdateDto>(foodUpdateDto);
        }

        public IDataResult<List<FoodDto>> GetFoodWithFoodCategories()
        {
            return new SuccessDataResult<List<FoodDto>>(_foodDal.GetFoodWithFoodCategories());
        }

        
    }
}
