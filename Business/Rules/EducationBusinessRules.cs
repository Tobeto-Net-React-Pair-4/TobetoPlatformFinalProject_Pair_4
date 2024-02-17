using Business.Abstracts;
using Business.Dtos.User.Responses;
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
    public class EducationBusinessRules : BaseBusinessRules<Education>
    {
        IEducationDal _educationDal;
        IUserService _userService;
        public EducationBusinessRules(IEducationDal educationDal, IUserService userService) : base(educationDal)
        {
            _educationDal = educationDal;
            _userService = userService;
        }

        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null) { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
