using Business.Dtos.CourseFavouritedByUser.Requests;
using Business.Dtos.CourseFavouritedByUser.Responses;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseFavouritedByUserService
    {
        Task<Paginate<GetListCourseFavouritedByUserResponse>> GetListAsync();
        Task<CreatedCourseFavouritedByUserResponse> AddAsync(CreateCourseFavouritedByUserRequest createCourseFavouritedByUserRequest);
        Task<DeletedCourseFavouritedByUserResponse> DeleteAsync(DeleteCourseFavouritedByUserRequest deleteCourseFavouritedByUserRequest);
        Task<Paginate<GetListUserResponse>> GetListByCourseIdAsync(Guid courseId);
    }
}
