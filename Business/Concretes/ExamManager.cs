using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Exam.Requests;
using Business.Dtos.Exam.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ExamManager : IExamService
    {
        private IExamDal _examDal;
        private IMapper _mapper;
        public ExamManager(IExamDal examDal, IMapper mapper)
        {
            _examDal = examDal;
            _mapper = mapper;
        }
        public async Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(createExamRequest);
            exam.Id = Guid.NewGuid();

            Exam createdExam = await _examDal.AddAsync(exam);
            return _mapper.Map<CreatedExamResponse>(createdExam);
        }

        public async Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest)
        {
            Exam exam = await _examDal.GetAsync(e => e.Id == deleteExamRequest.Id);
            await _examDal.DeleteAsync(exam);
            return _mapper.Map<DeletedExamResponse>(exam);
        }

        public async Task<GetByIdExamResponse> GetByIdAsync(GetByIdExamRequest getByIdExamRequest)
        {
            Exam exam = await _examDal.GetAsync(e => e.Id == getByIdExamRequest.Id);
            return _mapper.Map<GetByIdExamResponse>(exam);
        }

        public async Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest)
        {
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
