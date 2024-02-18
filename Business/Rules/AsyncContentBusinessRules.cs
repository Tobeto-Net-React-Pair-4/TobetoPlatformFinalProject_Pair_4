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
    public class AsyncContentBusinessRules : BaseBusinessRules<AsyncContent>
    {
        IAsyncContentDal _asyncContentDal;
        public AsyncContentBusinessRules(IAsyncContentDal asyncContentDal) : base(asyncContentDal) 
        {
            _asyncContentDal = asyncContentDal;            
        }
    }
}
