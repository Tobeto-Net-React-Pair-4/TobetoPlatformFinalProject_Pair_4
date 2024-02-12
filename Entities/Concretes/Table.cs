using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Table : Entity<Guid>
    {
        public int Count { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
