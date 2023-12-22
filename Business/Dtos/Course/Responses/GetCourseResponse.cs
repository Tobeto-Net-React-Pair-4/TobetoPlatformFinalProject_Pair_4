using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Course.Responses
{
    public class GetCourseResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string InstructorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public int ContentCount { get; set; }
    }
}
