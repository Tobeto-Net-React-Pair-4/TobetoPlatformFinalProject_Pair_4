using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<Paginate<GetListCourseResponse>> GetListAsync();
        Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest);
        Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest);
        Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest);
        Task<GetByIdCourseResponse> GetByIdAsync(GetByIdCourseRequest getByIdCourseRequest);
    }
}
