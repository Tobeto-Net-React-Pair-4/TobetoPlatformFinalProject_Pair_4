using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Exam
    {
        public bool True { get; set; }
        public bool False { get; set; }
        public string Empty { get; set; }
        public DateTime Time { get; set; }
        public int QuestionQuantity { get; set; }
        public string QuestionType { get; set; }
        public int Score { get; set; }
    }
}
