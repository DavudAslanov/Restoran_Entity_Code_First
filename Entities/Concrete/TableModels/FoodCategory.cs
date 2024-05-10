using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class FoodCategory:BaseEntity
    {
        public FoodCategory()
        {
            Foods = new HashSet<Food>();
        }

        public string Name { get; set; }

        public string IconName { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
