using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfUserDal : EfRepositoryBase<User, Guid, TobetoContext>, IUserDal
    {
        TobetoContext _context;
        public EfUserDal(TobetoContext context) : base(context)
        {
            _context = context;
        }
        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in _context.OperationClaims
                        join userOperationClaim in _context.UserOperationClaims
                            on operationClaim.Id equals userOperationClaim.OperationClaimId
                        where userOperationClaim.UserId == user.Id
                        select new OperationClaim { Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
