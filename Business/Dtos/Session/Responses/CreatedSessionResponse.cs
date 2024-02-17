using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Session.Responses
{
    public class CreatedSessionResponse
    {
        public Guid Id { get; set; }
        public Guid LiveContentId { get; set; }
        public string RecordUrl { get; set; }
        public string SessionUrl { get; set; }
        public DateTime StartOfTime { get; set; }
        public DateTime EndOfTime { get; set; }
    }
}
