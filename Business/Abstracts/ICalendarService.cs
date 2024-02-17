using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICalendarService
    {
        Task<Paginate<GetListCalendarResponse>> GetListAsync();
        Task<CreatedCalendarResponse> AddAsync(CreateCalendarRequest createCalendarRequest);
        Task<UpdatedCalendarResponse> UpdateAsync(UpdateCalendarRequest updateCalendarRequest);
        Task<DeletedCalendarResponse> DeleteAsync(Guid calendarId);
    }
}
