using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseAsyncContentService
    {
        Task<Paginate<GetListCourseAsyncContentResponse>> GetListAsync();
        Task<CreatedCourseAsyncContentResponse> AddAsync(CreateCourseAsyncContentRequest createCourseAsyncContentRequest);
        Task<UpdatedCourseAsyncContentResponse> UpdateAsync(UpdateCourseAsyncContentRequest updateCourseAsyncContentRequest);
        Task<DeletedCourseAsyncContentResponse> DeleteAsync(Guid Id);
        Task<GetCourseAsyncContentResponse> GetByIdAsync(Guid Id);
    }
}
