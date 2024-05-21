using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryDeleteDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string IconName { get; set; }

        public static FoodCategory ToFoodCategory(FoodCategoryUpdateDto dto)
        {
            FoodCategory foodcategory = new()
            {
               ID= dto.ID,
               Name= dto.Name,
               IconName=dto.IConName
            };
            return foodcategory;
        }
    }
}
