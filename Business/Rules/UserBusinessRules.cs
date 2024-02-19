using Business.Abstracts;
using Business.Constants;
using Business.Dtos.User.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    //public class UserBusinessRules : BaseBusinessRules<User>
    //{
    //    IUserDal _userDal;

    //    public UserBusinessRules(IUserDal userDal) : base(userDal)
    //    {
    //       _userDal = userDal;
    //    }

    //    public async Task OldPassword(UpdateUserRequest updateUserRequest)
    //    {
    //        var result = await _userDal.GetListAsync();
    //        foreach (var user in result.Items)
    //        {
    //            if (user.Id == updateUserRequest.Id)
    //            {
    //                if (user.PasswordHash == updateUserRequest.Password)
    //                {
    //                    throw new BusinessException(BusinessMessages.OldPassword);

    //                }
    //            }
    //        }

    //    }
    //}
}
