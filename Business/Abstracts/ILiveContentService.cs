using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveContent.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILiveContentService
    {
        Task<Paginate<GetListLiveContentResponse>> GetListAsync();
        Task<CreatedLiveContentResponse> AddAsync(CreateLiveContentRequest createLiveContentRequest);
        Task<UpdatedLiveContentResponse> UpdateAsync(UpdateLiveContentRequest updateLiveContentRequest);
        Task<DeletedLiveContentResponse> DeleteAsync(Guid liveContentId);
        Task<GetLiveContentResponse> GetByIdAsync(Guid liveContentId);
        Task<Paginate<GetListLiveContentResponse>> GetListByCourseIdAsync(Guid courseId);
        Task<CreatedCourseLiveContentResponse> AssignContentAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest);

    }
}
