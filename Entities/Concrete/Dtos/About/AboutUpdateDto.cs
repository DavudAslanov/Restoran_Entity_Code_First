
using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public static AboutUpdateDto ToAbout(About about)
        {
            AboutUpdateDto dto = new()
            {
                ID = about.ID,
                Description = about.Description,
            };
            return dto;
        }
        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new()
            {
                ID = dto.ID,
                Description = dto.Description,
            };
            return about;
        }
     
        

    }
}
