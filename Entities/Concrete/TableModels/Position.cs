using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Position:BaseEntity
    {

        public Position()
        {
            Teams = new HashSet<Team>();
        }
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
