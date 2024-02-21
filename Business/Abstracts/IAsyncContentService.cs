using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.LiveContent.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IAsyncContentService
    {
        Task<Paginate<GetListAsyncContentResponse>> GetListAsync();
        Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest);
        Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest);
        Task<DeletedAsyncContentResponse> DeleteAsync(Guid asyncContentId);
        Task<GetAsyncContentResponse> GetByIdAsync(Guid asyncContentId);
        Task<Paginate<GetListAsyncContentResponse>> GetListAsyncContentByCourseIdAsync(Guid courseId);
        Task<CreatedCourseAsyncContentResponse> AssignAsyncContentAsync(CreateCourseAsyncContentRequest createCourseAsyncContentRequest);
    }
}
