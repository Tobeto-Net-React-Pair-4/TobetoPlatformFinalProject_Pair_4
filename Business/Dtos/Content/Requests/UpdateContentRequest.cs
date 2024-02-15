using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Content.Requests
{
    public class UpdateContentRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Type { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Language { get; set; }
        public string Detail { get; set; }
    }
}
