using Business.Dtos.AsyncContent.Responses;
using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseAsyncContentService
    {
        Task<Paginate<GetListCourseAsyncContentResponse>> GetListAsync();
        Task<CreatedCourseAsyncContentResponse> AddAsync(CreateCourseAsyncContentRequest createCourseAsyncContentRequest);
        Task<DeletedCourseAsyncContentResponse> DeleteAsync(DeleteCourseAsyncContentRequest deleteCourseAsyncContentRequest);
        Task<Paginate<GetListAsyncContentResponse>> GetListByCourseIdAsync(Guid courseId);
    }
}
