using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using File = Entities.Concretes.File;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfFileDal : EfRepositoryBase<File, Guid, TobetoContext>, IFileDal
    {
        public EfFileDal(TobetoContext context) : base(context)
        {

        }
    }
}
