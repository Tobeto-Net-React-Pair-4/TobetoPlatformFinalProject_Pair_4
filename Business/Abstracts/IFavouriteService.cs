using Business.Dtos.Favourite.Requests;
using Business.Dtos.Favourite.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IFavouriteService
    {
        Task<Paginate<GetListFavouriteResponse>> GetListAsync();
        Task<GetFavouriteResponse> GetByIdAsync(GetFavouriteRequest getFavouriteRequest);
        Task<CreatedFavouriteResponse> AddAsync(CreateFavouriteRequest createFavouriteRequest);
        Task<UpdatedFavouriteResponse> UpdateAsync(UpdateFavouriteRequest updateFavouriteRequest);
        Task<DeletedFavouriteResponse> DeleteAsync(DeleteFavouriteRequest deleteFavouriteRequest);
    }
}
