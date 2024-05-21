using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsHomePage { get; set; }

        public string IconName { get; set; }
        public static Service ToService(ServiceUpdateDto dto)
        {
            Service service = new Service()
            {
                ID = dto.ID,
                Name = dto.Name,
                Description = dto.Description,
                IsHomePage = dto.IsHomePage,
                IconName = dto.IconName,
            };
            return service;
        }
    }
}
