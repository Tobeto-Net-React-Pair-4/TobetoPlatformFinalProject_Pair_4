using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.User.Responses;

namespace Business.Dtos.Course.Responses
{
    public class GetByIdCourseResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string InstructorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public int ContentCount { get; set; }
        public ICollection<GetUserResponse> Users { get; set; }

    }
}
