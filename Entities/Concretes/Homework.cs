using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Homework : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid LiveContentId { get; set; }
        public string Name { get; set; }
        public DateTime EndOfDate { get; set; }
        public string InstructorDescription { get; set; }
        public string StudentDescription { get; set; }
        public bool SendStatus { get; set; }
        public Course Course { get; set;}
        public LiveContent LiveContent { get; set; }
        public ICollection<HomeworkFile> HomeworkFiles { get; set; }

    }
}
