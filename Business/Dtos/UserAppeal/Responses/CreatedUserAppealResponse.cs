using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserAppeal.Responses
{
    public class CreatedUserAppealResponse
    {
        public Guid UserId { get; set; }
        public Guid AppealId { get; set; }
    }
}
