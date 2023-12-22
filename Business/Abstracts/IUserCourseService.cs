using Business.Dtos.Instructor.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Abstracts
{
    public interface IUserCourseService
    {
        Task<CreatedUserCourseResponse> AddAsync(CreateUserCourseRequest createUserCourseRequest);
        Task<Paginate<GetListUserCourseResponse>> GetListAsync();
    }
}
