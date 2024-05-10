using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Food:BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string IconName { get; set; }

        public int Price { get; set; }

        public bool IsHomePage { get; set; }

        public int FoodCategoryID { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
