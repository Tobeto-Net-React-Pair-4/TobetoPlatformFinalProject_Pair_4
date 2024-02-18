using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserOperationClaim.Responses
{
    public class DeletedUserOperationClaimResponse
    {
        public Guid UuserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
