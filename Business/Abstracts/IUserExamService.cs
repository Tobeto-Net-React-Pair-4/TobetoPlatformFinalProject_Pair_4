using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserExamService
    {
        Task<CreatedUserExamResponse> AddAsync(CreateUserExamRequest createUserExamRequest );
        Task<DeletedUserExamResponse> DeleteAsync(DeleteUserExamRequest deleteUserExamRequest);
        Task<GetUserExamResponse> GetAsync(GetUserExamRequest getUserExamRequest);
        Task<Paginate<GetListUserExamResponse>> GetListAsync();
    }
}
