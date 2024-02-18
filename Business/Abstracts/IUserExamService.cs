using Business.Dtos.Exam.Responses;
using Business.Dtos.User.Responses;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserExamService
    {
        Task<CreatedUserExamResponse> AddAsync(CreateUserExamRequest createUserExamRequest );
        Task<DeletedUserExamResponse> DeleteAsync(DeleteUserExamRequest deleteUserExamRequest);
        Task<Paginate<GetListUserExamResponse>> GetListAsync();
        Task<Paginate<GetListExamResponse>> GetListByUserIdAsync(Guid userId);

    }
}
