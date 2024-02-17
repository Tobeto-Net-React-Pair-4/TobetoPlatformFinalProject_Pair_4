using Business.Dtos.CourseFavouritedByUser.Requests;
using Business.Dtos.CourseFavouritedByUser.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseFavouritedByUserService
    {
        Task<Paginate<GetListCourseFavouritedByUserResponse>> GetListAsync();
        Task<CreatedCourseFavouritedByUserResponse> AddAsync(CreateCourseFavouritedByUserRequest createCourseFavouritedByUserRequest);
        Task<UpdatedCourseFavouritedByUserResponse> UpdateAsync(UpdateCourseFavouritedByUserRequest updateCourseFavouritedByUserRequest);
        Task<DeletedCourseFavouritedByUserResponse> DeleteAsync(Guid Id);
        Task<GetCourseFavouritedByUserResponse> GetByIdAsync(Guid Id);
    }
}
