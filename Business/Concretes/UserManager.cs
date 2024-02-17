using AutoMapper;
using Business.Abstracts;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using Core.Entities.Abstract;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;
        private UserBusinessRules _userBusinessRules;

        public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
        {
            User user = _mapper.Map<User>(createUserRequest);
            user.Id = Guid.NewGuid();

            User createdUser = await _userDal.AddAsync(user);

            return _mapper.Map<CreatedUserResponse>(createdUser);
        }

        public async Task<Paginate<GetListUserResponse>> GetListAsync()
        {
            var data = await _userDal.GetListAsync();
            return _mapper.Map<Paginate<GetListUserResponse>>(data);
        }
        public async Task<DeletedUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest)
        {
            User user = await _userDal.GetAsync(p => p.Id == deleteUserRequest.Id);
            await _userDal.DeleteAsync(user);
            return _mapper.Map<DeletedUserResponse>(user);
        }

        public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            await _userBusinessRules.OldPassword(updateUserRequest);

            User user = await _userDal.GetAsync(p => p.Id == updateUserRequest.Id);
            _mapper.Map(updateUserRequest, user);
            await _userDal.UpdateAsync(user);
            return _mapper.Map<UpdatedUserResponse>(user);
        }

        public List<IOperationClaim> GetClaims(IUser user)
        {
            return _userDal.GetClaims(user);
        }

        public async Task<User> GetByMailAsync(string mail)
        {
            return await _userDal.GetAsync(u => u.Email == mail);

        }
        public async Task<GetUserResponse> GetUserByMailAsync(string mail)
        {
            User user = await _userDal.GetAsync(u => u.Email == mail);

            return _mapper.Map<GetUserResponse>(user);

        }
        public async Task<GetByIdUserResponse> GetByIdAsync(GetByIdUserRequest getByIdUserRequest)
        {
            User user = await _userDal.GetAsync(u => u.Id == getByIdUserRequest.Id);
            return _mapper.Map<GetByIdUserResponse>(user);
        }

    }

}