using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Core.Entities.Abstract;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<Paginate<GetListUserResponse>> GetListAsync();
        Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest);
        Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest);
        Task<GetByIdUserResponse> GetByIdAsync(Guid userId);
        List<IOperationClaim> GetClaims(IUser user);
        Task<User> GetByMailAsync(string email);
        Task<GetUserResponse> GetUserByMailAsync(string email);
    }
}
