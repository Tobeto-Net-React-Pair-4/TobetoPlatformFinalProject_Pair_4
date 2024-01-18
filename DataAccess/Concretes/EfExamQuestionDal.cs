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
    public class EfExamQuestionDal : EfRepositoryBase<ExamQuestion, Guid, TobetoContext>, IExamQuestionDal
    {
        public EfExamQuestionDal(TobetoContext context) : base(context)
        {
        }
    }
}
