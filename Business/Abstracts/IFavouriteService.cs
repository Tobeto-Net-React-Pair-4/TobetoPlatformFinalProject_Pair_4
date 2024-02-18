using Business.Dtos.Favourite.Requests;
using Business.Dtos.Favourite.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IFavouriteService
    {
        Task<Paginate<GetListFavouriteResponse>> GetListAsync();
        Task<CreatedFavouriteResponse> AddAsync(CreateFavouriteRequest createFavouriteRequest);
        Task<UpdatedFavouriteResponse> UpdateAsync(UpdateFavouriteRequest updateFavouriteRequest);
        Task<DeletedFavouriteResponse> DeleteAsync(Guid favouriteId);
        Task<GetFavouriteResponse> GetByIdAsync(Guid favouriteId);
    }
}
