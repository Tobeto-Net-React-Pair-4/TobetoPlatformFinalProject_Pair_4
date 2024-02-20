using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.HomeworkFile.Responses
{
    public class DeletedHomeworkFileResponse
    {
        public Guid HomeworkId { get; set; }
        public Guid FileId { get; set; }
    }
}
