using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class ServiceDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsHomePage { get; set; }

        public string IconName { get; set; }

        public static List<ServiceDto> ToService(Service service)
        {
            ServiceDto dto = new ServiceDto()
            {
              ID= service.ID,
              Name= service.Name,
              Description= service.Description,
              IsHomePage= service.IsHomePage,
              IconName= service.IconName,
            };
            List<ServiceDto> dtoList = new List<ServiceDto>();
            dtoList.Add(dto);
            return dtoList;
        }
    }
}
