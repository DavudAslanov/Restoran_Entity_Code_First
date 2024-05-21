using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ContactDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public static List<ContactDto> ToContact(Contact contact)
        {
            ContactDto dto = new ContactDto()
            {
                ID = contact.ID,
                Name = contact.Name,
                Email = contact.Email,
                Title = contact.Title,
                Message = contact.Message,
            };
            List<ContactDto> dtoList = new List<ContactDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
