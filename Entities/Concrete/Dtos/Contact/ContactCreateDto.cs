
using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactCreateDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public static Contact ToContact(ContactCreateDto dto)
        {
            Contact contact = new()
            {
                Name = dto.Name,
                Email = dto.Email,
                Title = dto.Title,
                Message = dto.Message
            };
            return contact;
        }
    }
}
