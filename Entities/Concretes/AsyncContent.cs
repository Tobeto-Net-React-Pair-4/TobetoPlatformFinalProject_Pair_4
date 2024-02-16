using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class AsyncContent : Content
    {
        public string VideoUrl { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public ICollection<CourseAsyncContent> CourseAsyncContents { get; set; }
    }
}
