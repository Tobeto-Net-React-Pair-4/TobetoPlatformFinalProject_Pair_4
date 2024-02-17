using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IPasswordResetService
    {
        Task<Paginate<GetListPasswordResetResponse>> GetListAsync();
        Task<CreatedPasswordResetResponse> AddAsync(CreatePasswordResetRequest createPasswordResetRequest);
        Task<UpdatedPasswordResetResponse> UpdateAsync(UpdatePasswordResetRequest updatePasswordResetRequest);
        Task<DeletedPasswordResetResponse> DeleteAsync(Guid Id);
        Task<GetPasswordResetResponse> GetByIdAsync(Guid Id);
    }
}
