using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Security.Hashing;
using Entities.Concretes;

namespace Business.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        IUserService _userService;
        public AuthBusinessRules(IUserService userService)
        {
            _userService = userService;
        }

        public async Task UserExists(string email)
        {
            if (await _userService.GetByMail(email) != null)
                throw new BusinessException(BusinessMessages.UserExists);
        }

        public async Task<User> UserToCheck(UserLoginRequest userLoginRequest)
        {
            var userToCheck = await _userService.GetByMail(userLoginRequest.Email);

            if (userToCheck == null)
                throw new BusinessException(BusinessMessages.UserNotExists);

            

            else if ( !HashingHelper.VerifyPasswordHash(userLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                throw new BusinessException(BusinessMessages.LoginPasswordError);

            return userToCheck;

        }

    }
}
