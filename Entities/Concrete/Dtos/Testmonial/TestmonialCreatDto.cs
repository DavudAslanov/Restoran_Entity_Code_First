using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestmonialCreatDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FeedBack { get; set; }

        public string PhotoUrl { get; set; }

        public static Testmonial ToTestmonial(TestmonialCreatDto dto)
        {
            Testmonial Testmonial = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FeedBack = dto.FeedBack,
                PhotoUrl = dto.PhotoUrl,
            };
            return Testmonial;
        }
    }
}
