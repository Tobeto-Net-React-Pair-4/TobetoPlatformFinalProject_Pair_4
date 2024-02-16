using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Repositories;
using Core.Entities.Concrete;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Rules
{
    public class BaseBusinessRules<TEntity> where TEntity : Entity<Guid>
    {
        private readonly IAsyncRepository<TEntity, Guid> _efDal;
        public BaseBusinessRules(IAsyncRepository<TEntity, Guid> efDal)
        {
            _efDal = efDal;
        }
        public async Task<TEntity> CheckIfExistsById(Guid id)
        {
            var entity = await _efDal.GetAsync(t => t.Id == id);
            if (entity == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return entity;
        }
    }
}
