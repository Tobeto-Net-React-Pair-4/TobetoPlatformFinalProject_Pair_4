using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.LiveContent.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseLiveContentService
    {
        Task<CreatedCourseLiveContentResponse> AddAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest);
        Task<DeletedCourseLiveContentResponse> DeleteAsync(DeleteCourseLiveContentRequest deleteCourseLiveContentRequest);
        Task<Paginate<GetListCourseLiveContentResponse>> GetListAsync();
        Task<Paginate<GetListLiveContentResponse>> GetListByCourseIdAsync(Guid courseId);


    }
}
