using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Appeal.Requests
{
    public class CreateAppealRequest
    {
        public string Title { get; set; }
        public string Form { get; set; }
        public string File { get; set; }
    }
}
