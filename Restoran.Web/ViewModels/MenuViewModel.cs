using Entities.Concrete.Dtos;

namespace Restoran.Web.ViewModels
{
    public class MenuViewModel
    {
        public List<FoodDto> FoodsDto { get; set; }

        public List<FoodCategoryDto> FoodCategoriesDto { get; set; }
    }
}
