using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public int  Deleted { get; set; }

        public int CreatedDate { get; set; }

        public int LastUpdatedDate { get; set;}
    }
}
