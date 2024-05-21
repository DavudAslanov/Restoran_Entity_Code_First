using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public int Price { get; set; }

        public bool IsHomePage { get; set; }

        public int FoodCategoryID { get; set; }

        public static Food ToFood(FoodCreateDto dto)
        {
            Food food = new()
            {
                Name= dto.Name,
                Description= dto.Description,
                PhotoUrl= dto.PhotoUrl,
                Price= dto.Price,
                IsHomePage= dto.IsHomePage,
                FoodCategoryID= dto.FoodCategoryID
            };
            return food;
        }
    }
}
