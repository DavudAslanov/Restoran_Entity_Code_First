using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Bussines.Abstract
{
    public interface IFoodService
    {
        IResult Add(FoodCreateDto dto,IFormFile photoUrl, string webRootPath);

        IResult Update(FoodUpdateDto dto,IFormFile photoUrl, string webRootPath);

        IResult Delete(int id);

        IDataResult<List<FoodDto>> GetFoodWithFoodCategories();

        IDataResult<Food> GetById(int id);
    }
}
