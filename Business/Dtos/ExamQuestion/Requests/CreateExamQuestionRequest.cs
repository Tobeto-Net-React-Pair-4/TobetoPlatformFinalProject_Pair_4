using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.ExamQuestion.Requests
{
    public class CreateExamQuestionRequest
    {
        public Guid ExamId { get; set; }
        public Guid TrueAnswerId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
