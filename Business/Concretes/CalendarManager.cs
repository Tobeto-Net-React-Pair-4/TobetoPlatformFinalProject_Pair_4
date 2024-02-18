using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Calendar.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Calendar = Entities.Concretes.Calendar;

namespace Business.Concretes
{
    public class CalendarManager : ICalendarService
    {
        private ICalendarDal _calendarDal;
        private IMapper _mapper;
        private CalendarBusinessRules _calendarBusinessRules;
        public CalendarManager(ICalendarDal calendarDal, IMapper mapper, CalendarBusinessRules calendarBusinessRules)
        {
            _calendarDal = calendarDal;
            _mapper = mapper;
            _calendarBusinessRules = calendarBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedCalendarResponse> AddAsync(CreateCalendarRequest createCalendarRequest)
        {
            await _calendarBusinessRules.CheckIfCourseExists(createCalendarRequest.CourseId);

            Calendar Calendar = _mapper.Map<Calendar>(createCalendarRequest);
            Calendar.Id = Guid.NewGuid();

            Calendar createdCalendar = await _calendarDal.AddAsync(Calendar);
            return _mapper.Map<CreatedCalendarResponse>(createdCalendar);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedCalendarResponse> DeleteAsync(Guid calendarId)
        {
            await _calendarBusinessRules.CheckIfExistsById(calendarId);

            Calendar Calendar = await _calendarDal.GetAsync(p => p.Id == calendarId);
            await _calendarDal.DeleteAsync(Calendar);
            return _mapper.Map<DeletedCalendarResponse>(Calendar);
        }

        public Task<GetCalendarResponse> GetByIdAsync(Guid calendarId)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedCalendarResponse> UpdateAsync(UpdateCalendarRequest updateCalendarRequest)
        {
            await _calendarBusinessRules.CheckIfExistsById(updateCalendarRequest.Id);
            await _calendarBusinessRules.CheckIfCourseExists(updateCalendarRequest.CourseId);

            Calendar Calendar = await _calendarDal.GetAsync(p => p.Id == updateCalendarRequest.Id);
            _mapper.Map(updateCalendarRequest, Calendar);
            Calendar = await _calendarDal.UpdateAsync(Calendar);
            return _mapper.Map<UpdatedCalendarResponse>(Calendar);
        }
        public async Task<GetCalendarResponse> GetByIdAsync(Guid Id)
        {
            Calendar calendar = await _calendarDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetCalendarResponse>(calendar);
        }


    }
}
