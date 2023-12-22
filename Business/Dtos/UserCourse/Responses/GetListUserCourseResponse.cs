using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Concretes;
using System.Threading.Tasks;
using Business.Dtos.Course.Responses;

namespace Business.Dtos.UserCourse.Responses
{
    public class GetListUserCourseResponse
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public GetUserResponse User { get; set; }
        public GetCourseResponse Course { get; set; }


    }
}
