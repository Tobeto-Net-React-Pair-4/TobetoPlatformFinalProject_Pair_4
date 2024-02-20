using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.QuestionAnswer.Requests;
using Business.Dtos.QuestionAnswer.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class QuestionAnswerManager : IQuestionAnswerService
    {
        private IQuestionAnswerDal _questionAnswerDal;
        private IMapper _mapper;
        public QuestionAnswerManager(IQuestionAnswerDal questionAnswerDal, IMapper mapper)
        {
            _questionAnswerDal = questionAnswerDal;
            _mapper = mapper;
        }
        public async Task<CreatedQuestionAnswerResponse> AddAsync(CreateQuestionAnswerRequest createQuestionAnswerRequest)
        {
            QuestionAnswer questionAnswer = _mapper.Map<QuestionAnswer>(createQuestionAnswerRequest);
            questionAnswer.Id = Guid.NewGuid();
            QuestionAnswer createdQuestionAnswer = await _questionAnswerDal.AddAsync(questionAnswer);
            return _mapper.Map<CreatedQuestionAnswerResponse>(questionAnswer);
        }

        public async Task<DeletedQuestionAnswerResponse> DeleteAsync(Guid questionAnswerId)
        {
            QuestionAnswer questionAnswer = await _questionAnswerDal.GetAsync(qa => qa.Id == questionAnswerId);
            await _questionAnswerDal.DeleteAsync(questionAnswer);
            return _mapper.Map<DeletedQuestionAnswerResponse>(questionAnswer);
        }

        public async Task<GetByIdQuestionAnswerResponse> GetByIdAsync(Guid questionAnswerId)
        {
            QuestionAnswer questionAnswer = await _questionAnswerDal.GetAsync
                (qa => qa.Id == questionAnswerId,
                include: p => p.Include(eq => eq.ExamQuestion));
            return _mapper.Map<GetByIdQuestionAnswerResponse>(questionAnswer);
        }
        public async Task<UpdatedQuestionAnswerResponse> UpdateAsync(UpdateQuestionAnswerRequest updateQuestionAnswerRequest)
        {
            QuestionAnswer questionAnswer = await _questionAnswerDal.GetAsync(qa => qa.Id == updateQuestionAnswerRequest.Id);
            _mapper.Map(updateQuestionAnswerRequest, questionAnswer);
            questionAnswer = await _questionAnswerDal.UpdateAsync(questionAnswer);
            return _mapper.Map<UpdatedQuestionAnswerResponse>(questionAnswer);
        }

        public async Task<Paginate<GetListQuestionAnswerResponse>> GetListAsync()
        {
            var data = await _questionAnswerDal.GetListAsync
                (include: p => p.Include(eq => eq.ExamQuestion));
            return _mapper.Map<Paginate<GetListQuestionAnswerResponse>>(data);
        }

    }
}
