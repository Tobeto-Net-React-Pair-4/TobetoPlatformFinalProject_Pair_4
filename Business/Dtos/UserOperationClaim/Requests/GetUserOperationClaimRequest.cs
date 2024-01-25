using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserOperationClaim.Requests
{
    public class GetUserOperationClaimRequest
    {
        public Guid UserId { get; set; }
        public Guid OperationId { get; set; }
    }
}
