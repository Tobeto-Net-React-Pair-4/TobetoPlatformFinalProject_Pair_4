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
    public class ExamBusinessRules : BaseBusinessRules<Exam>
    {
        IExamDal _examDal;
        public ExamBusinessRules(IExamDal examDal) : base(examDal)
        {
            _examDal = examDal;
        }
    }
}
