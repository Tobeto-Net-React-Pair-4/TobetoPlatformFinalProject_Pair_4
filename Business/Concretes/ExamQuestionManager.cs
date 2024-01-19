using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.ExamQuestion.Requests;
using Business.Dtos.ExamQuestion.Responses;
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
        public ExamQuestionManager(IExamQuestionDal examQuestionDal, IMapper mapper)
        {
            _examQuestionDal = examQuestionDal;
            _mapper = mapper;
        }
        public async Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest)
        {
            ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(createExamQuestionRequest);
            examQuestion.Id = Guid.NewGuid();

            ExamQuestion createdExamQuestion = await _examQuestionDal.AddAsync(examQuestion);
            return _mapper.Map<CreatedExamQuestionResponse>(createdExamQuestion);
        }

        public async Task<DeletedExamQuestionResponse> DeleteAsync(DeleteExamQuestionRequest deleteExamQuestionRequest)
        {
            ExamQuestion examQuestion = await _examQuestionDal.GetAsync(eq => eq.Id == deleteExamQuestionRequest.Id);
            await _examQuestionDal.DeleteAsync(examQuestion);
            return _mapper.Map<DeletedExamQuestionResponse>(examQuestion);
        }

        public async Task<GetByIdExamQuestionResponse> GetByIdAsync(GetByIdExamQuestionRequest getByIdExamQuestionRequest)
        {
            ExamQuestion examQuestion = await _examQuestionDal.GetAsync(eq => eq.Id == getByIdExamQuestionRequest.Id,
                include: eq => eq.Include(e => e.Exam));
            return _mapper.Map<GetByIdExamQuestionResponse>(examQuestion);

        }
        public async Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest)
        {
            ExamQuestion examQuestion = await _examQuestionDal.GetAsync(eq => eq.Id == updateExamQuestionRequest.Id);
            _mapper.Map(updateExamQuestionRequest, examQuestion);
            examQuestion = await _examQuestionDal.UpdateAsync(examQuestion);
            return _mapper.Map<UpdatedExamQuestionResponse>(examQuestion);
        }

        public async Task<Paginate<GetListExamQuestionResponse>> GetListAsync()
        {
            var data = await _examQuestionDal.GetListAsync(include: eq => eq.Include(e => e.Exam));
            return _mapper.Map<Paginate<GetListExamQuestionResponse>>(data);
        }

    }
}
