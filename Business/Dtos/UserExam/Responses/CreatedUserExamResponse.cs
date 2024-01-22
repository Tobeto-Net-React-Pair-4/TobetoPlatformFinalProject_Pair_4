using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Exam.Responses;
using Business.Dtos.User.Responses;

namespace Business.Dtos.UserExam.Responses
{
    public class CreatedUserExamResponse
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
    }
}
