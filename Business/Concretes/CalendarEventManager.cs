using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CalendarEventManager : ICalendarEventService
    {
        public Task<CreatedCalendarEventResponse> Add(CreateCalendarEventRequest createCalendarEventRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedCalendarEventResponse> Delete(DeleteCalendarEventRequest deleteCalendarEventRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListCalendarEventResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdatedCalendarEventResponse> Update(UpdateCalendarEventRequest updateCalendarEventRequest)
        {
            throw new NotImplementedException();
        }
    }
}
