using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Contact:BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

    }
}
