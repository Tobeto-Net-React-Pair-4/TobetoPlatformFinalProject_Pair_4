using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserOperationClaim.Responses
{
    public class GetUserOperationClaimResponse
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
        public ICollection<GetListUserResponse> Users { get; set; }

    }
}
