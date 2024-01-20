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
    public interface ICalendarEventService
    {
        Task<Paginate<GetListCalendarEventResponse>> GetListAsync();
        Task<CreatedCalendarEventResponse> AddAsync(CreateCalendarEventRequest createCalendarEventRequest);
        Task<UpdatedCalendarEventResponse> UpdateAsync(UpdateCalendarEventRequest updateCalendarEventRequest);
        Task<DeletedCalendarEventResponse> DeleteAsync(DeleteCalendarEventRequest deleteCalendarEventRequest);
    }
}
