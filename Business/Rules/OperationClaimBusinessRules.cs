using Business.Abstracts;
using Core.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules<OperationClaim>
    {
        private readonly IOperationClaimDal _operationClaimDal;
        private readonly IOperationClaimService _operationClaimService;
        public OperationClaimBusinessRules(IOperationClaimDal operationClaimDal, IOperationClaimService operationClaimService) : base(operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
            _operationClaimService = operationClaimService;
        }
    }
}
