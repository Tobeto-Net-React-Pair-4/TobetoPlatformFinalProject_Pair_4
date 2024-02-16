using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class CourseLikedByUser : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public Course Course { get; set; }
        public User User { get; set; }
    }
}
