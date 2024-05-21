
using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryCreateDto
    {
        public string CategoryName { get; set; }

        public string IConName { get; set; }

        public static FoodCategory ToFoodCategory(FoodCategoryCreateDto dto)
        {
            FoodCategory foodcategory = new()
            {
                Name=dto.CategoryName,
                IconName=dto.IConName
            };
            return foodcategory;
        }
    }
}
