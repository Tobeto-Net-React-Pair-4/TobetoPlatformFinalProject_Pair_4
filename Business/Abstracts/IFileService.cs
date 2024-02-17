using Business.Dtos.File.Requests;
using Business.Dtos.File.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IFileService
    {
        Task<Paginate<GetListFileResponse>> GetListAsync();
        Task<CreatedFileResponse> AddAsync(CreateFileRequest createFileRequest);
        Task<UpdatedFileResponse> UpdateAsync(UpdateFileRequest updateFileRequest);
        Task<DeletedFileResponse> DeleteAsync(Guid Id);
        Task<GetFileResponse> GetByIdAsync(Guid Id);
    }
}
