using Business.Abstracts;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
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
        public ExamBusinessRules(IExamDal examDal, IUserService userService) : base(examDal)
        {
            _examDal = examDal;
        }
    }
}
