using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserCourse.Requests
{
    public class CreateUserCourseRequest
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }

        //userlist verilmeli ?
        //public ICollection<GetListUserResponse> Users { get; set; }
        //public ICollection<GetListUserResponse> Users { get; set; }


    }
}
