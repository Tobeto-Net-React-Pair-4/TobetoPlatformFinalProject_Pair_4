using Business.Abstracts;
using Business.Dtos.Exam.Responses;
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
    public class ExamQuestionBusinessRules : BaseBusinessRules<ExamQuestion>
    {
        IExamQuestionDal _examQuestionDal;
        IExamService _examService;
        public ExamQuestionBusinessRules(IExamQuestionDal examQuestionDal, IExamService examService) : base(examQuestionDal)
        {
            _examQuestionDal = examQuestionDal;
            _examService = examService;
        }
        public async Task CheckIfExamExists(Guid examId)
        {
            GetByIdExamResponse exam = await _examService.GetByIdAsync(examId);
            if (exam == null) { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
