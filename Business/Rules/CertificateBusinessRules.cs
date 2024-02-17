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
    public class CertificateBusinessRules : BaseBusinessRules<Certificate>
    {
        ICertificateDal _certificateDal;
        IUserService _userService;
        public CertificateBusinessRules(ICertificateDal certificateDal, IUserService userService) : base(certificateDal) 
        {
            _certificateDal = certificateDal;
            _userService = userService;
        }

        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
        }
    }
}
