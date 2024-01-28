using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserOperationClaim.Requests
{
    public class CreateUserOperationClaimRequest
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
