using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Calendar.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

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

        public async Task<DeletedCalendarResponse> DeleteAsync(Guid Id)
        {
            Calendar Calendar = await _calendarDal.GetAsync(p => p.Id == Id);
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
        public async Task<GetCalendarResponse> GetByIdAsync(Guid Id)
        {
            Calendar calendar = await _calendarDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetCalendarResponse>(calendar);
        }


    }
}
