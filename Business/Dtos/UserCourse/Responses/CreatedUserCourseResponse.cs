using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserCourse.Responses
{
    public class CreatedUserCourseResponse
    {
        //public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }

        //public ICollection<GetListUserResponse> Users { get; set; }


    }
}
