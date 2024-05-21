using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ServiceCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsHomePage { get; set; }

        public string IconName { get; set; }
        public static Service ToService(ServiceCreateDto dto)
        {
            Service service = new Service()
            {
                Name = dto.Name,
                Description = dto.Description,
                IsHomePage = dto.IsHomePage,
                IconName = dto.IconName,
            };
            return service;
        }
    }
}
