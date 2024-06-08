using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutDto
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public static List<AboutDto> ToAbout(About about)
        {
            AboutDto dto = new AboutDto()
            {
                ID = about.ID,
                Description = about.Description,
            };
            List<AboutDto> dtoList = new List<AboutDto>();
            dtoList.Add(dto);
            return dtoList;
        }
        public static About ToAbouts(AboutDto dto)
        {
            About about = new()
            {
              Description= dto.Description,
            };
            return about;
        }

    }
}
