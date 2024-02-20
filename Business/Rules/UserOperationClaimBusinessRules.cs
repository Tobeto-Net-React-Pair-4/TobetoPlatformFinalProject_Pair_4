using Business.Abstracts;
using Business.Constants;
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
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IUserService _userService;
        public UserOperationClaimBusinessRules
            (IUserOperationClaimDal userOperationClaimDal, IUserService userService) : base(userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
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

        public async Task CheckIfAlreadyAssigned(Guid userId, Guid operationClaimId)
        {
            UserOperationClaim entity = await _userOperationClaimDal.GetAsync
                (uoc => uoc.UserId == userId && uoc.OperationClaimId == operationClaimId);
            if (entity != null)
            {
                throw new BusinessException("Çoktan yetkilendirilmiş");
            }
        }
    }
}
