using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class PositionCreateDto
    {
        public string Name { get; set; }

        public static Position ToPosition(PositionCreateDto dto)
        {
            Position position = new()
            {
                Name = dto.Name,
            };
            return position;
        }
    }
}
