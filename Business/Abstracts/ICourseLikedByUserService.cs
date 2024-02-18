using Business.Dtos.CourseLikedByUser.Requests;
using Business.Dtos.CourseLikedByUser.Responses;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseLikedByUserService
    {
        Task<Paginate<GetListCourseLikedByUserResponse>> GetListAsync();
        Task<CreatedCourseLikedByUserResponse> AddAsync(CreateCourseLikedByUserRequest createCourseLikedByUserRequest);
        Task<DeletedCourseLikedByUserResponse> DeleteAsync(DeleteCourseLikedByUserRequests deleteCourseLikedByUserRequests);
        Task<Paginate<GetListUserResponse>> GetListByCourseIdAsync(Guid courseId);
    }
}
