using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Appeal.Requests
{
    public class UpdateAppealRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Form { get; set; }
        public string File { get; set; }
        public string AppealStatus { get; set; }
        public string FormStatus { get; set; }
        public string FileStatus { get; set; }
    }
}
