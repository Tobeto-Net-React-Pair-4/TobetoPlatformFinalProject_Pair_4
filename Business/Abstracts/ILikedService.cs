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
    public interface ILikedService
    {
        Task<Paginate<GetListLikedResponse>> GetListAsync();
        Task<GetLikedResponse> GetByIdAsync(GetLikedRequest getLikedRequest);
        Task<CreatedLikedResponse> AddAsync(CreateLikedRequest createLikedRequest);
        Task<UpdatedLikedResponse> UpdateAsync(UpdateLikedRequest updateLikedRequest);
        Task<DeletedLikedResponse> DeleteAsync(DeleteLikedRequest deleteLikedRequest);
    }
}
