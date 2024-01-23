using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Exam.Requests
{
    public class CreateExamRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Time { get; set; }
        public int QuestionQuantity { get; set; }
        public string ExamType { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int Score { get; set; } = 0;
        public int TrueAnswerCount { get; set; } = 0;
        public int FalseAnswerCount { get; set; } = 0;
        public int EmptyAnswerCount { get; set; } = 0;
        public DateTime ExamStartDate { get; set; }
        public DateTime ExamEndDate { get; set; }
    }
}
