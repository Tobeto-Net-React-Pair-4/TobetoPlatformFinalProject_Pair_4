using Business.Dtos.Liked.Requests;
using Business.Dtos.Liked.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILikeService
    {
        Task<Paginate<GetListLikeResponse>> GetListAsync();
        Task<GetLikeResponse> GetByIdAsync(Guid likeId);
        Task<CreatedLikeResponse> AddAsync(CreateLikeRequest createLikedRequest);
        Task<UpdatedLikeResponse> UpdateAsync(UpdateLikeRequest updateLikedRequest);
        Task<DeletedLikeResponse> DeleteAsync(Guid likeId);
    }
}
