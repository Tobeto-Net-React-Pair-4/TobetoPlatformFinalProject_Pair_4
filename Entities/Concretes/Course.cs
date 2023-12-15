using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Course : Entity<Guid>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Category category { get; set; }
    }
}
