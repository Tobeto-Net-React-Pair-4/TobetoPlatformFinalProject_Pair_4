using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserExam.Requests
{
    public class CreateUserExamRequest
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
    }
}
