using Business.Dtos.Course.Responses;
using Business.Dtos.UserCalendar;
using Business.Dtos.UserCalendar.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserCalendarService
    {
        Task<CreatedUserCalendarResponse> AddAsync(CreateUserCalendarRequest createUserCalendarRequest);
        Task<Paginate<GetListUserCalendarResponse>> GetListAsync();
        Task<DeletedUserCalendarResponse> DeleteAsync(DeleteUserCalendarRequest deleteUserCalendarRequest);
        Task<Paginate<GetListCalendarResponse>> GetListByUserIdAsync(Guid userId);
    }
}
