using Business.Dtos.Content.Responses;
using Business.Dtos.ContentLikedByUser.Requests;
using Business.Dtos.ContentLikedByUser.Response;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IContentLikedByUserService
    {
        Task<Paginate<GetListContentLikedByUserResponse>> GetListAsync();
        Task<CreatedContentLikedByUserResponse> AddAsync(CreateContentLikedByUserRequest createContentLikedByUserRequest);
        Task<DeletedContentLikedByUserResponse> DeleteAsync(DeleteContentLikedByUserRequest deleteContentLikedByUserRequest);
        Task<Paginate<GetListUserResponse>> GetListByContentIdAsync(Guid contentId);
    }
}
