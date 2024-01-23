using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Experience.Requests
{
    public class CreateExperinceRequest
    {
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public string City { get; set; }
        public DateTime BusinessStartDate { get; set; }
        public DateTime BusinessEndDate { get; set; }
        public bool Status { get; set; }
        public string BusinessDescription { get; set; }
    }
}
