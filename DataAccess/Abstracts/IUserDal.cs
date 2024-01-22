using Core.DataAccess.Repositories;
using Core.Entities.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IUserDal : IRepository<User, Guid>, IAsyncRepository<User, Guid>
    {
        List<IOperationClaim> GetClaims(IUser user);
    }
}
