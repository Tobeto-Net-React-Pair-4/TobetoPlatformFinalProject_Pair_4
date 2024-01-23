using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Concrete;


namespace Entities.Concretes
{
    public class ExamQuestion : Entity<Guid>
    {
        public Guid ExamId { get; set; }
        public Guid TrueAnswerId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Exam Exam { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
