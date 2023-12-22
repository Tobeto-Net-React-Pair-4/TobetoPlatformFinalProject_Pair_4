using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Category.Requests;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CalendarEventManager : ICalendarEventService
    {
        private ICalendarEventDal _calendarEventDal;
        private IMapper _mapper;
        public CalendarEventManager(ICalendarEventDal calendarEventDal, IMapper mapper)
        {
            _calendarEventDal = calendarEventDal;
            _mapper = mapper;
        }

        public async Task<CreatedCalendarEventResponse> Add(CreateCalendarEventRequest createCalendarEventRequest)
        {
            CalendarEvent calendarEvent = _mapper.Map<CalendarEvent>(createCalendarEventRequest);
            calendarEvent.Id = Guid.NewGuid();

            CalendarEvent createdCalendarEvent = await _calendarEventDal.AddAsync(calendarEvent);

            return _mapper.Map<CreatedCalendarEventResponse>(createdCalendarEvent);
        }

        public async Task<DeletedCalendarEventResponse> Delete(DeleteCalendarEventRequest deleteCalendarEventRequest)
        {
            CalendarEvent calendarEvent = await _calendarEventDal.GetAsync(p => p.Id == deleteCalendarEventRequest.Id);
            await _calendarEventDal.DeleteAsync(calendarEvent);
            return _mapper.Map<DeletedCalendarEventResponse>(calendarEvent);
        }

        public async Task<Paginate<GetListCalendarEventResponse>> GetListAsync()
        {
            var data = await _calendarEventDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCalendarEventResponse>>(data);
        }

        public async Task<UpdatedCalendarEventResponse> Update(UpdateCalendarEventRequest updateCalendarEventRequest)
        {
            CalendarEvent calendarEvent = await _calendarEventDal.GetAsync(p => p.Id == updateCalendarEventRequest.Id);
            _mapper.Map(updateCalendarEventRequest, calendarEvent);
            calendarEvent = await _calendarEventDal.UpdateAsync(calendarEvent);
            return _mapper.Map<UpdatedCalendarEventResponse>(calendarEvent);
        }
    }
}
