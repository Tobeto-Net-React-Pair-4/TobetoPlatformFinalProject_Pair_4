using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Assignment : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string AssignmentType { get; set; }
        public string VideoUrl { get; set; }
        public Course Course { get; set; }
        public ICollection<File> Files { get; set; }
    }
}
