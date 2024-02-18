using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Exam.Requests;
using Business.Dtos.Exam.Responses;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IExamService
    {
        Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest);
        Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest);
        Task<DeletedExamResponse> DeleteAsync(Guid examId);
        Task<GetByIdExamResponse> GetByIdAsync(Guid examId);
        Task<Paginate<GetListExamResponse>> GetListAsync();
        Task<Paginate<GetListExamResponse>> GetListByUserIdAsync(Guid userId);
        Task<CreatedUserExamResponse> AssignExamToUserAsync(CreateUserExamRequest createUserExamRequest);
    }
}
