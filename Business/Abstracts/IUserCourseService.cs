using Business.Dtos.Course.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserCourseService
    {
        Task<CreatedUserCourseResponse> AddAsync(CreateUserCourseRequest createUserCourseRequest);
        Task<DeletedUserCourseResponse> DeleteAsync(DeleteUserCourseRequest deleteUserCourseRequest);
        Task<Paginate<GetListUserCourseResponse>> GetListAsync();
        Task<Paginate<GetListCourseResponse>> GetListByUserIdAsync(Guid userId);
    }
}
