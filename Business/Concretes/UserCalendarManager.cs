using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.UserCalendar;
using Business.Dtos.UserCalendar.Responses;
using Business.Dtos.UserCourse.Responses;
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
    public class UserCalendarManager : IUserCalendarService
    {
        IUserCalendarDal _userCalendarDal;
        IMapper _mapper;

        public UserCalendarManager(IUserCalendarDal userCalendarDal, IMapper mapper)
        {
            _userCalendarDal = userCalendarDal;
            _mapper = mapper;
        }
        public async Task<CreatedUserCalendarResponse> AddAsync(CreateUserCalendarRequest createUserCalendarRequest)
        {
            UserCalendar userCalendar = _mapper.Map<UserCalendar>(createUserCalendarRequest);
            var createdUserCalendar = await _userCalendarDal.AddAsync(userCalendar);
            CreatedUserCalendarResponse createdUserCalendarResponse = _mapper.Map<CreatedUserCalendarResponse>(createdUserCalendar);
            return createdUserCalendarResponse;
        }

        public async Task<DeletedUserCalendarResponse> DeleteAsync(DeleteUserCalendarRequest deleteUserCalendarRequest)
        {          
            UserCalendar userCalendar = await _userCalendarDal.GetAsync(uc => uc.UserId == deleteUserCalendarRequest.UserId);
            await _userCalendarDal.DeleteAsync(userCalendar);
            return _mapper.Map<DeletedUserCalendarResponse>(userCalendar);
        }

        public async Task<Paginate<GetListUserCalendarResponse>> GetListAsync()
        {
            var result = await _userCalendarDal.GetListAsync();
            return _mapper.Map<Paginate<GetListUserCalendarResponse>>(result);
        }

        public async Task<Paginate<GetListCalendarResponse>> GetListByUserIdAsync(Guid userId)
        {
            var userCalendars = await _userCalendarDal.GetListAsync(uc => uc.UserId == userId);
            var calendars = _mapper.Map<Paginate<GetListCalendarResponse>>(userCalendars);
            return calendars;
        }
    }
}
