using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserAppeal.Requests
{
    public class DeleteUserAppealRequest
    {
        public Guid UserId { get; set; }
        public Guid AppealId { get; set; }
    }
}
