using Business.Dtos.ContentLikedByUser.Requests;
using Business.Dtos.ContentLikedByUser.Response;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IContentLikedByUserService
    {
        Task<Paginate<GetListContentLikedByUserResponse>> GetListAsync();
        Task<CreatedContentLikedByUserResponse> AddAsync(CreateContentLikedByUserRequest createContentLikedByUserRequest);
        Task<DeletedContentLikedByUserResponse> DeleteAsync(DeleteContentLikedByUserRequest deleteContentLikedByUserRequest);
        //Task<UpdatedContentLikedByUserResponse> UpdateAsync(UpdateContentLikedByUserRequest updateContentLikedByUserRequest);
        // GET LIST BY USER ID LAZIM BURAYA !-!-!
    }
}
