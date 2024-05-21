
using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IConName { get; set; }

        public static FoodCategoryUpdateDto ToFood(FoodCategory foodCategory)
        {
            FoodCategoryUpdateDto dto = new()
            {
               ID = foodCategory.ID,
               Name = foodCategory.Name,
               IConName=foodCategory.IconName,
            };
            return dto;
        }
        public static FoodCategory ToFoodCategory(FoodCategoryUpdateDto dto)
        {
            FoodCategory foodcategory = new FoodCategory()
            {
                ID = dto.ID,
                Name = dto.Name,
                IconName = dto.IConName
            };
            return foodcategory;
        }

      
    }
}
