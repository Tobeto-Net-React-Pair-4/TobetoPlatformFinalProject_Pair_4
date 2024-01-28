using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.PersonalInfo.Responses
{
    public class CreatedPersonalInfoResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
