using AutoMapper;
using Business.Abstracts;
using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class PasswordResetManager : IPasswordResetService
    {
        private IPasswordResetDal _passwordResetDal;
        private IMapper _mapper;
        public PasswordResetManager(IPasswordResetDal passwordResetDal, IMapper mapper)
        {
            _passwordResetDal = passwordResetDal;
            _mapper = mapper;
        }
        public async Task<CreatedPasswordResetResponse> AddAsync(CreatePasswordResetRequest createPasswordResetRequest)
        {

            PasswordReset passwordReset = _mapper.Map<PasswordReset>(createPasswordResetRequest);
            passwordReset.Id = Guid.NewGuid();

            PasswordReset createdPasswordReset = await _passwordResetDal.AddAsync(passwordReset);
            return _mapper.Map<CreatedPasswordResetResponse>(createdPasswordReset);
        }

        public async Task<DeletedPasswordResetResponse> DeleteAsync(Guid Id)
        {

            PasswordReset passwordReset = await _passwordResetDal.GetAsync(p => p.Id == Id);
            await _passwordResetDal.DeleteAsync(passwordReset);
            return _mapper.Map<DeletedPasswordResetResponse>(passwordReset);
        }


        public async Task<Paginate<GetListPasswordResetResponse>> GetListAsync()
        {
            var data = await _passwordResetDal.GetListAsync();
            return _mapper.Map<Paginate<GetListPasswordResetResponse>>(data);
        }

        public async Task<UpdatedPasswordResetResponse> UpdateAsync(UpdatePasswordResetRequest updatePasswordResetRequest)
        {
            PasswordReset passwordReset = await _passwordResetDal.GetAsync(p => p.Id == updatePasswordResetRequest.Id);
            _mapper.Map(updatePasswordResetRequest, passwordReset);
            await _passwordResetDal.UpdateAsync(passwordReset);
            return _mapper.Map<UpdatedPasswordResetResponse>(passwordReset);
        }
        public async Task<GetPasswordResetResponse> GetByIdAsync(Guid Id)
        {
            PasswordReset passwordReset = await _passwordResetDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetPasswordResetResponse>(passwordReset);
        }
    }
}
