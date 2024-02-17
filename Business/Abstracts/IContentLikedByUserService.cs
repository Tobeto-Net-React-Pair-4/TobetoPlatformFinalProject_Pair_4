using Business.Dtos.ContentLikedByUser.Requests;
using Business.Dtos.ContentLikedByUser.Response;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IContentLikedByUserService
    {
        Task<Paginate<GetListContentLikedByUserResponse>> GetListAsync();
        Task<CreatedContentLikedByUserResponse> AddAsync(CreateContentLikedByUserRequest createContentLikedByUserRequest);
        Task<UpdatedContentLikedByUserResponse> UpdateAsync(UpdateContentLikedByUserRequest updateContentLikedByUserRequest);
        Task<DeletedContentLikedByUserResponse> DeleteAsync(Guid Id);
        Task<GetContentLikedByUserResponse> GetByIdAsync(Guid Id);
    }
}
