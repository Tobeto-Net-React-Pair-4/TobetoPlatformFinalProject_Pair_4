using Business.Abstracts;
using Core.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class PersonalInfoBusinessRules : BaseBusinessRules<PersonalInfo>
    {
        IPersonalInfoService _personalInfoService;
        IPersonalInfoDal _personalInfoDal;
        public PersonalInfoBusinessRules(IPersonalInfoService personalInfoService, IPersonalInfoDal personalInfoDal) : base(personalInfoDal)
        {
            _personalInfoService = personalInfoService;
            _personalInfoDal = personalInfoDal;
        }
    }
}
