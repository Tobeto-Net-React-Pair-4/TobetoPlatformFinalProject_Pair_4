using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AppealBusinessRules : BaseBusinessRules<Appeal>
    {
        IAppealDal _appealDal;
        public AppealBusinessRules(IAppealDal appealDal) : base(appealDal)
        {
            _appealDal = appealDal;
        }
    }
}
