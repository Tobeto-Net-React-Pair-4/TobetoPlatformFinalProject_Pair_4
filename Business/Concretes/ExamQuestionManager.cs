using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.ExamQuestion.Requests;
using Business.Dtos.ExamQuestion.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ExamQuestionManager : IExamQuestionService
    {
        private IExamQuestionDal _examQuestionDal;
        private IMapper _mapper;
        private ExamQuestionBusinessRules _examQuestionBusinessRules;
        public ExamQuestionManager(IExamQuestionDal examQuestionDal, IMapper mapper, ExamQuestionBusinessRules examQuestionBusinessRules)
        {
            _examQuestionDal = examQuestionDal;
            _mapper = mapper;
            _examQuestionBusinessRules = examQuestionBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest)
        {
            await _examQuestionBusinessRules.CheckIfExamExists(createExamQuestionRequest.ExamId);

            ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(createExamQuestionRequest);
            examQuestion.Id = Guid.NewGuid();

            ExamQuestion createdExamQuestion = await _examQuestionDal.AddAsync(examQuestion);
            return _mapper.Map<CreatedExamQuestionResponse>(createdExamQuestion);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedExamQuestionResponse> DeleteAsync(Guid examQuestionId)
        {
            await _examQuestionBusinessRules.CheckIfExistsById(examQuestionId);

            ExamQuestion examQuestion = await _examQuestionDal.GetAsync(eq => eq.Id == examQuestionId);
            await _examQuestionDal.DeleteAsync(examQuestion);
            return _mapper.Map<DeletedExamQuestionResponse>(examQuestion);
        }

        public async Task<GetByIdExamQuestionResponse> GetByIdAsync(Guid examQuestionId)
        {
            await _examQuestionBusinessRules.CheckIfExistsById(examQuestionId);

            ExamQuestion examQuestion = await _examQuestionDal.GetAsync(eq => eq.Id == examQuestionId,
                include: eq => eq.Include(e => e.Exam));
            return _mapper.Map<GetByIdExamQuestionResponse>(examQuestion);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest)
        {
            await _examQuestionBusinessRules.CheckIfExistsById(updateExamQuestionRequest.Id);
            await _examQuestionBusinessRules.CheckIfExamExists(updateExamQuestionRequest.ExamId);
            await _examQuestionBusinessRules.CheckIfAnswerExists(updateExamQuestionRequest.TrueAnswerId);

            ExamQuestion examQuestion = await _examQuestionDal.GetAsync(eq => eq.Id == updateExamQuestionRequest.Id);
            _mapper.Map(updateExamQuestionRequest, examQuestion);
            examQuestion = await _examQuestionDal.UpdateAsync(examQuestion);
            return _mapper.Map<UpdatedExamQuestionResponse>(examQuestion);
        }

        public async Task<Paginate<GetListExamQuestionResponse>> GetListAsync()
        {
            var data = await _examQuestionDal.GetListAsync(include: eq => eq.Include(eq => eq.Exam));
            return _mapper.Map<Paginate<GetListExamQuestionResponse>>(data);
        }

        public async Task<Paginate<GetListExamQuestionResponse>> GetListByExamIdAsync(Guid examId)
        {
            await _examQuestionBusinessRules.CheckIfExamExists(examId);

            var data = await _examQuestionDal.GetListAsync(eq => eq.ExamId == examId, include: eq => eq.Include(eq => eq.Exam));
            return _mapper.Map<Paginate<GetListExamQuestionResponse>>(data);
        }
    }
}
