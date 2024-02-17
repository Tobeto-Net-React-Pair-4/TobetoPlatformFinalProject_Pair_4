using Business.Dtos.Course.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserCourseService
    {
        Task<CreatedUserCourseResponse> AddAsync(CreateUserCourseRequest createUserCourseRequest);
        Task<Paginate<GetListUserCourseResponse>> GetListAsync();
        Task<Paginate<GetListCourseResponse>> GetListByUserIdAsync(Guid userId);
    }
}
