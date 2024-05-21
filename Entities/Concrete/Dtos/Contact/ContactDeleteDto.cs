using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ContactDeleteDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public static Contact ToContact(ContactUpdateDto dto)
        {
            Contact contact = new()
            {
                ID = dto.ID,
                Name = dto.Name,
                Email = dto.Email,
                Title = dto.Title,
                Message = dto.Message,
            };
            return contact;
        }
    }
}
