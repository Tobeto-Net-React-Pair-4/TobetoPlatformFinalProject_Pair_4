using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.User.Responses;
using Business.Dtos.UserOperationClaim.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserOperationClaimBusinessRules : BaseBusinessRules<UserOperationClaim>
    {
        IUserOperationClaimDal _userOperationClaimDal;
        IUserService _userService;
        IOperationClaimService _operationClaimService;
        public UserOperationClaimBusinessRules
            (IUserOperationClaimDal userOperationClaimDal, IOperationClaimService operationClaimService, IUserService userService) : base(userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimService = operationClaimService;
            _userService = userService;
        }
        public async Task<UserOperationClaim> CheckIfUserOperationClaimExists(Guid operationClaimId, Guid userId)
        {
            UserOperationClaim userOperationClaim = await _userOperationClaimDal.GetAsync
                (uoc => uoc.OperationClaimId == operationClaimId && uoc.UserId == userId);
            if (userOperationClaim == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return userOperationClaim;
        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfOperationClaimExists(Guid operationClaimId)
        {
            GetOperationClaimResponse operationClaim = await _operationClaimService.GetByIdAsync(operationClaimId);
            if (operationClaim == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
