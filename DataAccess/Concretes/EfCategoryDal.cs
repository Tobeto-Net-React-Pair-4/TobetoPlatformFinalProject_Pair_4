using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfCategoryDal : EfRepositoryBase<Category, Guid, TobetoContext>, ICategoryDal
    {
        public EfCategoryDal(TobetoContext context) : base(context)
        {
        }
    }
}
