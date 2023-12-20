using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class UserCourse : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }

        //public string UserInfo { get; set; }
        //public ICollection<string> UsersCourseList { get; set; }

    }
}
