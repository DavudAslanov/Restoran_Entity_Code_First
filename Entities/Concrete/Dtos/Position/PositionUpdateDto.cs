using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class PositionUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static PositionUpdateDto ToPosition(Position position)
        {
            PositionUpdateDto dto = new()
            {
               ID= position.ID,
               Name= position.Name,
            };
            return dto;
        }
        public static Position ToPosition(PositionUpdateDto dto)
        {
            Position position = new Position()
            {
                ID = dto.ID,
                Name = dto.Name,
            };
            return position;
        }
    }
}
