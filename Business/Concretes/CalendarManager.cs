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
    public class CalendarManager : ICalendarService
    {
        private ICalendarDal _calendarDal;
        private IMapper _mapper;
        public CalendarManager(ICalendarDal calendarDal, IMapper mapper)
        {
            _calendarDal = calendarDal;
            _mapper = mapper;
        }

        public async Task<CreatedCalendarResponse> AddAsync(CreateCalendarRequest createCalendarRequest)
        {
            Calendar Calendar = _mapper.Map<Calendar>(createCalendarRequest);
            Calendar.Id = Guid.NewGuid();

            Calendar createdCalendar = await _calendarDal.AddAsync(Calendar);

            return _mapper.Map<CreatedCalendarResponse>(createdCalendar);
        }

        public async Task<DeletedCalendarResponse> DeleteAsync(DeleteCalendarRequest deleteCalendarRequest)
        {
            Calendar Calendar = await _calendarDal.GetAsync(p => p.Id == deleteCalendarRequest.Id);
            await _calendarDal.DeleteAsync(Calendar);
            return _mapper.Map<DeletedCalendarResponse>(Calendar);
        }

        public async Task<Paginate<GetListCalendarResponse>> GetListAsync()
        {
            var data = await _calendarDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCalendarResponse>>(data);
        }

        public async Task<UpdatedCalendarResponse> UpdateAsync(UpdateCalendarRequest updateCalendarRequest)
        {
            Calendar Calendar = await _calendarDal.GetAsync(p => p.Id == updateCalendarRequest.Id);
            _mapper.Map(updateCalendarRequest, Calendar);
            Calendar = await _calendarDal.UpdateAsync(Calendar);
            return _mapper.Map<UpdatedCalendarResponse>(Calendar);
        }
    }
}
