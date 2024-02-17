using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Calendar.Responses;
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
using System.Globalization;
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

        public Task<CreatedCalendarResponse> AddAsync(CreateCalendarRequest createCalendarRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedCalendarResponse> DeleteAsync(Guid calendarId)
        {
            throw new NotImplementedException();
        }

        public Task<GetCalendarResponse> GetByIdAsync(Guid calendarId)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListCalendarResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdatedCalendarResponse> UpdateAsync(UpdateCalendarRequest updateCalendarRequest)
        {
            throw new NotImplementedException();
        }
    }
}
