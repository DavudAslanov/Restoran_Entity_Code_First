

using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactUpdateDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }


        public static ContactUpdateDto ToContact(Contact contact)
        {
            ContactUpdateDto dto = new()
            {
                ID = contact.ID,
                Name = contact.Name,
                Email = contact.Email,
                Title = contact.Title,
                Message = contact.Message,
            };
            return dto;
        }
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
