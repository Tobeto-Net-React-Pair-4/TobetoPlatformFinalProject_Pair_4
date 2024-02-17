using Business.Dtos.Course.Responses;
using Business.Dtos.UserCalendar;
using Business.Dtos.UserCalendar.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserCalendarService
    {
        Task<CreatedUserCalendarResponse> AddAsync(CreateUserCalendarRequest createUserCalendarRequest);
        Task<Paginate<GetListUserCalendarResponse>> GetListAsync();
        Task<GetUserCalendarResponse> GetByIdAsync(GetUserCalendarRequest getUserCalendarRequest);
        Task<DeletedUserCalendarResponse> DeleteAsync(DeleteUserCalendarRequest deleteUserCalendarRequest);
        Task<Paginate<GetListCalendarResponse>> GetListByUserIdAsync(Guid userId);
    }
}
