
using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Bussines.Abstract
{
    public interface IFoodCategoryService
    {
        IResult Add(FoodCategoryCreateDto dto);

        IResult Update(FoodCategoryUpdateDto dto);

        IResult Delete(int id);

        IDataResult<List<FoodCategoryDto>> GetAllFoodCategories();

        IDataResult<FoodCategoryUpdateDto> GetById(int id);
    }
}
