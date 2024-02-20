using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
using Business.Dtos.HomeworkFile.Requests;
using Business.Dtos.HomeworkFile.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IHomeworkService
    {
        Task<Paginate<GetListHomeworkResponse>> GetListAsync();
        Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest);
        Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest);
        Task<DeletedHomeworkResponse> DeleteAsync(Guid homeworkId);
        Task<GetHomeworkResponse> GetByIdAsync(Guid homeworkId);
        Task<Paginate<GetListHomeworkResponse>> GetListByCourseIdAsync(Guid courseId);
        Task<CreatedHomeworkFileResponse> AssignFileToHomeworkAsync(CreateHomeworkFileRequest createHomeworkFileRequest);
        // user - homework
        // user - file
    }
}
