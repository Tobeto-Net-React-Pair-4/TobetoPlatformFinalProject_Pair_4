using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.InstrutorSession.Requests
{
    public class UpdateInstructorSessionRequest
    {
        public Guid InstructorId { get; set; }
        public Guid SessionId { get; set; }
    }
}
