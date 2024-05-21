using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        public static List<FoodCategoryDto> ToAbout(FoodCategory foodcategory)
        {
            FoodCategoryDto dto= new FoodCategoryDto()
            {
                Id=foodcategory.ID,
                Name=foodcategory.Name,
                IconName=foodcategory.IconName,
            };
            List<FoodCategoryDto> dtoList = new List<FoodCategoryDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
