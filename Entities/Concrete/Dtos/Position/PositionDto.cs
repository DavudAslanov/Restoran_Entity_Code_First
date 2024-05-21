using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PositionDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<PositionDto> ToAbout(Position position)
        {
            PositionDto dto = new PositionDto()
            {
                ID= position.ID,
                Name= position.Name,
            };
            List<PositionDto> dtoList = new List<PositionDto>();
            dtoList.Add(dto);
            return dtoList;
        }

    }
}
