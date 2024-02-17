using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class HomeworkFile : Entity<Guid>
    {
        public Guid HomeworkId { get; set; }
        public Guid FileId { get; set; }
        public Homework Homework {  get; set; } 
        public File File { get; set; }  
    }
}
