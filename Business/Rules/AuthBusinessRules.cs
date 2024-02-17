using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class AuthBusinessRules : BaseBusinessRules<User>
    {
        IUserService _userService;
        public AuthBusinessRules(IUserService userService, IUserDal userDal) : base(userDal)
        {
            _userService = userService;
        }

        public async Task UserExists(string email)
        {
            if (await _userService.GetByMailAsync(email) != null)
                throw new BusinessException(BusinessMessages.UserExists);
        }

        public async Task<User> UserToCheck(UserLoginRequest userLoginRequest)
        {
            var userToCheck = await _userService.GetByMailAsync(userLoginRequest.Email);

            if (userToCheck == null)
                throw new BusinessException(BusinessMessages.UserNotExists);

            

            else if ( !HashingHelper.VerifyPasswordHash(userLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                throw new BusinessException(BusinessMessages.LoginPasswordError);

            return userToCheck;

        }

    }
}
