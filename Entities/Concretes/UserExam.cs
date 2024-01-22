using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class UserExam : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
        public User User { get; set; }
        public Exam Exam { get; set; }
    }
}
