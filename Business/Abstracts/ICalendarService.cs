
using Business.Dtos.Calendar.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICalendarService
    {
        Task<Paginate<GetListCalendarResponse>> GetListAsync();
        Task<CreatedCalendarResponse> AddAsync(CreateCalendarRequest createCalendarRequest);
        Task<UpdatedCalendarResponse> UpdateAsync(UpdateCalendarRequest updateCalendarRequest);
        Task<DeletedCalendarResponse> DeleteAsync(Guid calendarId);
        Task<GetCalendarResponse> GetByIdAsync(Guid calendarId);

    }
}
