using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class LiveContent : Content
    {
        public ICollection<Session> Sessions {  get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<CourseLiveContent> CourseLiveContents { get; set; }

    }
}
