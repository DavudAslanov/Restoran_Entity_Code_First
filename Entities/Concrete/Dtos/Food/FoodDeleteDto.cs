using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class FoodDeleteDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public int Price { get; set; }

        public bool IsHomePage { get; set; }

        public int FoodCategoryID { get; set; }
        public static Food ToFood(FoodUpdateDto dto)
        {
            Food food = new()
            {
                ID = dto.ID,
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
