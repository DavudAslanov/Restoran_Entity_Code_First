using Core.DataAcces.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAcess.Abstract
{
    public interface IFoodDal : IBaseInterfeys<Food>
    {
        List<FoodDto> GetFoodWithFoodCategories();
    }


}
