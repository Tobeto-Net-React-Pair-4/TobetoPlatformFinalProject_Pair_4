using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfPersonalInfoDal : EfRepositoryBase<PersonalInfo, Guid, TobetoContext>, IPersonalInfoDal
    {
        public EfPersonalInfoDal(TobetoContext context) : base(context)
        {
        }
    }
}
