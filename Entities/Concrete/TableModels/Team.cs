using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string instagramUrl { get; set; }

        public int PositionID { get; set; }

        public bool IsHomePage { get; set; }
        public virtual Position Position { get; set; }
    }
}
