using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.HomeworkFile.Requests
{
    public class DeleteHomeworkFileRequest
    {
        public Guid HomeworkId { get; set; }
        public Guid FileId { get; set; }
    }
}
