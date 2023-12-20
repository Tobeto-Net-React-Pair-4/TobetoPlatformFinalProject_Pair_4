using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Course.Responses;

namespace Business.Dtos.Instructor.Responses
{
    public class GetByIdInstructorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetByIdCourseResponse> Courses { get; set; }
    }
}
