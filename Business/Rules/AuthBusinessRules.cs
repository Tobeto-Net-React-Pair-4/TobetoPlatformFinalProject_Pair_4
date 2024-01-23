using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Abstract;
using Core.Utilities.Security.Hashing;

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

        public async Task<IUser> UserToCheck(UserLoginRequest loginRequest)
        {
            var userToCheck = await _userService.GetByMail(loginRequest.Email);

            if (userToCheck == null || !HashingHelper.VerifyPasswordHash(loginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                throw new BusinessException(BusinessMessages.LoginError);

            return userToCheck;
        }

    }
}
