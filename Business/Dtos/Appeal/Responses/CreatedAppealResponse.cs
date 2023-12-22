using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Appeal.Responses
{
    public class CreatedAppealResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Form { get; set; }
        public string File { get; set; }
    }
}
