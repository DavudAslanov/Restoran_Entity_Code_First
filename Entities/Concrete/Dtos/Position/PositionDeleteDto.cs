using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class PositionDeleteDto
    {
        public  int ID { get; set; }
        public string Name { get; set; }
        public static Position Toposition(PositionUpdateDto dto)
        {
            Position position = new()
            {
               ID=dto.ID,
               Name=dto.Name,
            };
            return position;
        }
    }
}
