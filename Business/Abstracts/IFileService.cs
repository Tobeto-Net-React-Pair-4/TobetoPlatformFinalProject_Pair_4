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
        Task<DeletedFileResponse> DeleteAsync(Guid fileId);
        Task<GetFileResponse> GetByIdAsync(Guid fileId);
        Task<Paginate<GetListFileResponse>> GetListByHomeworkIdAsync(Guid homeworkId);

    }
}
