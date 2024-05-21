using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public int Price { get; set; }

        public bool IsHomePage { get; set; }

        public int FoodCategoryID { get; set; }

        public static FoodUpdateDto ToFood(Food food)
        {
            FoodUpdateDto dto = new()
            {
              ID = food.ID,
              Name = food.Name,
              Description = food.Description,
              PhotoUrl = food.PhotoUrl,
              Price = food.Price,
              IsHomePage = food.IsHomePage,
              FoodCategoryID=food.FoodCategoryID
            };
            return dto;
        }
        public static Food ToFood(FoodUpdateDto dto)
        {
            Food food = new()
            {
                ID=dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                Price = dto.Price,
                IsHomePage = dto.IsHomePage,
                FoodCategoryID = dto.FoodCategoryID
            };
            return food;
        }
    }
}
