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
    public class ExperienceBusinessRules : BaseBusinessRules<Experience>
    {
        IExperienceDal _experienceDal;
        IUserService _userService;
        public ExperienceBusinessRules(IExperienceDal experienceDal, IUserService userService) : base(experienceDal)
        {
            _experienceDal = experienceDal;
            _userService = userService;
        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
