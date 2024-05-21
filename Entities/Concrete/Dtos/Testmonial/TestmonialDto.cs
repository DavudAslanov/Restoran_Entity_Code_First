using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TestmonialDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FeedBack { get; set; }

        public string PhotoUrl { get; set; }

        public static List<TestmonialDto> ToTestmonial(Testmonial testmonial)
        {
            TestmonialDto dto = new TestmonialDto()
            {
               ID= testmonial.ID,
               FirstName= testmonial.FirstName,
               LastName= testmonial.LastName,
               FeedBack= testmonial.FeedBack,
               PhotoUrl= testmonial.PhotoUrl
            };
            List<TestmonialDto> dtoList = new List<TestmonialDto>();
            dtoList.Add(dto);
            return dtoList;
        }

    }
}
