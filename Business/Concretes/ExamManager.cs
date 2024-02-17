using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Exam.Requests;
using Business.Dtos.Exam.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ExamManager : IExamService
    {
        private IExamDal _examDal;
        private IMapper _mapper;
        private ExamBusinessRules _examBusinessRules;
        public ExamManager(IExamDal examDal, IMapper mapper, ExamBusinessRules examBusinessRules)
        {
            _examDal = examDal;
            _mapper = mapper;
            _examBusinessRules = examBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(createExamRequest);
            exam.Id = Guid.NewGuid();

            Exam createdExam = await _examDal.AddAsync(exam);
            return _mapper.Map<CreatedExamResponse>(createdExam);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedExamResponse> DeleteAsync(Guid examId)
        {
            await _examBusinessRules.CheckIfExistsById(examId);

            Exam exam = await _examDal.GetAsync(e => e.Id == examId);
            await _examDal.DeleteAsync(exam);
            return _mapper.Map<DeletedExamResponse>(exam);
        }

        public async Task<GetByIdExamResponse> GetByIdAsync(Guid examId)
        {
            await _examBusinessRules.CheckIfExistsById(examId);

            Exam exam = await _examDal.GetAsync(e => e.Id == examId);
            return _mapper.Map<GetByIdExamResponse>(exam);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest)
        {
            await _examBusinessRules.CheckIfExistsById(updateExamRequest.Id);

            Exam exam = await _examDal.GetAsync(e => e.Id == updateExamRequest.Id);
            _mapper.Map(updateExamRequest, exam);
            exam = await _examDal.UpdateAsync(exam);
            return _mapper.Map<UpdatedExamResponse>(exam);
        }

        public async Task<Paginate<GetListExamResponse>> GetListAsync()
        {
            var data = await _examDal.GetListAsync();
            return _mapper.Map<Paginate<GetListExamResponse>>(data);
        }
    }
}
