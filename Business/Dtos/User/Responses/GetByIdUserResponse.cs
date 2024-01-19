using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Course.Responses;

namespace Business.Dtos.User.Responses
{
    public class GetByIdUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetCourseResponse> Courses { get; set; }
    }
}
