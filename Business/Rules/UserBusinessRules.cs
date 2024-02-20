using Business.Abstracts;
using Business.Constants;
using Business.Dtos.User.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class UserBusinessRules : BaseBusinessRules<User>
    {
        private readonly IUserDal _userDal;

        public UserBusinessRules(IUserDal userDal) : base(userDal)
        {
           _userDal = userDal;
        }

        //public async Task OldPassword(UpdateUserRequest updateUserRequest)
        //{
        //    var result = await _userDal.GetListAsync();
        //    foreach (var user in result.Items)
        //    {
        //        if (user.Id == updateUserRequest.Id)
        //        {
        //            if (user.PasswordHash == updateUserRequest.Password)
        //            {
        //                throw new BusinessException(BusinessMessages.OldPassword);
        //
        //            }
        //        }
        //    }
        //
        //}
        public async Task<User> CheckIfExistsByMail(string email)
        {

            var entity = await _userDal.GetAsync(u => u.Email == email);
            if (entity == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return entity;
        }
    }
}
