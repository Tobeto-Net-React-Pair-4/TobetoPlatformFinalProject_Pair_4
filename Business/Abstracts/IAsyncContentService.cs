using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IAsyncContentService
    {
        Task<Paginate<GetListAsyncContentResponse>> GetListAsync();
        Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest);
        Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest);
        Task<DeletedAsyncContentResponse> DeleteAsync(Guid asynContenId);
        Task<GetAsyncContentResponse> GetByIdAsync(Guid asynContenId);
    }
}
