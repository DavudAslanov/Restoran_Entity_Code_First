
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.Dtos
{
    public class FoodDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsHomePage { get; set; }

        public string FoodCategoryName { get; set; }
        public int FoodCategoryID { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoUrl { get; set; }

        public static List<FoodDto> ToFood(Food food)
        {
            FoodDto dto = new FoodDto()
            {
                ID = food.ID,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price,
                IsHomePage = food.IsHomePage,
                PhotoUrl=food.PhotoUrl,
                FoodCategoryID=food.FoodCategoryID,
            };
            List<FoodDto> dtoList = new List<FoodDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
