using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.UserAppeal.Requests;
using Business.Dtos.UserAppeal.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserAppealService
    {
        Task<CreatedUserAppealResponse> AddAsync(CreateUserAppealRequest createUserAppealRequest);
        Task<DeletedUserAppealResponse> DeleteAsync(DeleteUserAppealRequest deleteUserAppealRequest);
        Task<GetUserAppealRequest> GetAsync(GetUserAppealRequest getUserAppealRequest);
        Task<Paginate<GetListUserAppealResponse>> GetListAsync();
    }
}
