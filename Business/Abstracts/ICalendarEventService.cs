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
        Task<CreatedCalendarEventResponse> Add(CreateCalendarEventRequest createCalendarEventRequest);
        Task<UpdatedCalendarEventResponse> Update(UpdateCalendarEventRequest updateCalendarEventRequest);
        Task<DeletedCalendarEventResponse> Delete(DeleteCalendarEventRequest deleteCalendarEventRequest);
    }
}
