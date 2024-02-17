using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.UserCalendar;
using Business.Dtos.UserCalendar.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserCalendar : IUserCalendarService
    {
        public Task<CreatedUserCalendarResponse> AddAsync(CreateUserCalendarRequest createUserCalendarRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedUserCalendarResponse> DeleteAsync(DeleteUserCalendarRequest deleteUserCalendarRequest)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserCalendarResponse> GetByIdAsync(GetUserCalendarRequest getUserCalendarRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListUserCalendarResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListCalendarResponse>> GetListByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
