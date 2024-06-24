using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class FoodCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsHomePage { get; set; }

        public int FoodCategoryID { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoUrl { get; set; }

        public static Food ToFood(FoodCreateDto dto)
        {
            Food food = new()
            {
                Name= dto.Name,
                Description= dto.Description,
                Price= dto.Price,
                IsHomePage= dto.IsHomePage,
                PhotoUrl= dto.PhotoUrl,
                FoodCategoryID= dto.FoodCategoryID
            };
            return food;
        }
    }
}
