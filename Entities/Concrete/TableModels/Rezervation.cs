using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Rezervation:BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RezervationTime { get; set; }

        public byte PeopleCount { get; set; }

        public bool IsContact { get; set; }
        public string Message { get; set; }
    }
}
