using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<Paginate<GetListUserResponse>> GetListAsync();
        Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest);
        Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest);
        Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest);
        Task<GetByIdUserResponse> GetByIdAsync(GetByIdUserRequest getByIdUserRequest);
    }
}
