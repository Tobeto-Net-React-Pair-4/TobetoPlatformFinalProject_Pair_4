using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.CourseLikedByUser.Requests
{
    public class GetCourseLikedByUserRequests
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
