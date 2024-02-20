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
        public OperationClaimBusinessRules(IOperationClaimDal operationClaimDal) : base(operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }
    }
}
