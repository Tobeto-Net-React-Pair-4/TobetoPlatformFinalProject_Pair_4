using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.LiveContent.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseLiveContentService
    {
        Task<CreatedCourseLiveContentResponse> AddAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest);
        Task<UpdatedCourseLiveContentResponse> UpdateAsync(UpdateCourseLiveContentRequest updateCourseLiveContentRequest);
        Task<DeletedCourseLiveContentResponse> DeleteAsync(DeleteCourseLiveContentRequest deleteCourseLiveContentRequest);
        Task<GetCourseLiveContentResponse> GetAsync(GetCourseLiveContentRequest getCourseLiveContentRequest);
        Task<Paginate<GetListCourseLiveContentResponse>> GetListAsync();
        Task<Paginate<GetListLiveContentResponse>> GetListByCourseAsync(Guid courseId);


    }
}
