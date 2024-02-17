using Business.Dtos.CourseLikedByUser.Requests;
using Business.Dtos.CourseLikedByUser.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseLikedByUserService
    {
        Task<Paginate<GetListCourseLikedByUserResponse>> GetListAsync();
        Task<CreatedCourseLikedByUserResponse> AddAsync(CreateCourseLikedByUserRequest createCourseLikedByUserRequest);
        Task<UpdatedCourseLikedByUserResponse> UpdateAsync(UpdateCourseLikedByUserRequest updateCourseLikedByUserRequest);
        Task<DeletedCourseLikedByUserResponse> DeleteAsync(Guid Id);
        Task<GetCourseLikedByUserResponse> GetByIdAsync(Guid Id);
    }
}
