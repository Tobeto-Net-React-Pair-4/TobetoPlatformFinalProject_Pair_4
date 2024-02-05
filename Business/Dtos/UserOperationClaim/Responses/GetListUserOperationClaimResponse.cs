using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserOperationClaim.Responses
{
    public class GetListUserOperationClaimResponse
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
        public GetUserResponse User { get; set; }
        public GetOperationClaimResponse OperationClaim {get; set;}
    }
}
