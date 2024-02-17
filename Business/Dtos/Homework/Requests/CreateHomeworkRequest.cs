using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Homework.Requests
{
    public class CreateHomeworkRequest
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public bool SendStatus { get; set; }
        public DateTime EndOfDate { get; set; }
        public string InstructorDescription { get; set; }
        public string StudentDescription { get; set; }
    }
}
