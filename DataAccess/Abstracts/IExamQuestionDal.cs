using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IExamQuestionDal : IRepository<ExamQuestion, Guid>, IAsyncRepository<ExamQuestion, Guid>
    {
    }
}
