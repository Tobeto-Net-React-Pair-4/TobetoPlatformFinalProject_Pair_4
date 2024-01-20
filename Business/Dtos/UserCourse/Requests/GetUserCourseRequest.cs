using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserCourse.Requests
{
    public class GetUserCourseRequest
    {
        public Guid? UserId { get; set; }
        public Guid? CourseId { get; set; }
    }
}
