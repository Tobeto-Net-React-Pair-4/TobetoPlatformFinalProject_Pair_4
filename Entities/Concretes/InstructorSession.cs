using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class InstructorSession:Entity<Guid>
    {
        public Guid InstructorId { get; set; }
        public Guid SessionId { get; set; }
        public Instructor Instructor { get; set; }
        public Session Session { get; set; }    
    }
}
