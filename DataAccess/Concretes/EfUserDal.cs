using Core.DataAccess.Repositories;
using Core.Entities.Abstract;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Concretes
{
    public class EfUserDal : EfRepositoryBase<User, Guid, TobetoContext>, IUserDal
    {
        TobetoContext _tobetoContext;
        public EfUserDal(TobetoContext context) : base(context)
        {
            _tobetoContext = context;
        }
        public List<IOperationClaim> GetClaims(IUser user)
        {
            var result = from operationClaim in _tobetoContext.OperationClaims
                         join userOperationClaim in _tobetoContext.UserOperationsClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select (IOperationClaim)(new OperationClaim { Name = operationClaim.Name });
            return result.ToList();
        }
    }
}
