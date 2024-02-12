using Business.Abstracts;
using Business.Constants;
using Business.Dtos.User.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Business.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        IUserService _userService;

        public UserBusinessRules(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OldPassword(UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.GetListAsync();
            foreach (var user in result.Items)
            {
                if (user.Id == updateUserRequest.Id)
                {
                    if (user.Password == updateUserRequest.Password)
                    {
                        throw new BusinessException(BusinessMessages.OldPassword);

                    }
                }
            }

        }
    }
}
