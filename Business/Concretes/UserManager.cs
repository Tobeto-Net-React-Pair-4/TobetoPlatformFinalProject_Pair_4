﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public async Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
        {
            User user = _mapper.Map<User>(createUserRequest);
            user.Id = Guid.NewGuid();

            User createdUser = await _userDal.AddAsync(user);

            return _mapper.Map<CreatedUserResponse>(createdUser);
        }

        public async Task<Paginate<GetListedUserResponse>> GetListAsync()
        {
            var data = await _userDal.GetListAsync();
            return _mapper.Map<Paginate<GetListedUserResponse>>(data);
        }
        public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            User user = await _userDal.GetAsync(p => p.Id == deleteUserRequest.UserId);
            await _userDal.DeleteAsync(user);
            return _mapper.Map<DeletedUserResponse>(user);
        }

        public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
        {
            User user = await _userDal.GetAsync(p => p.Id == updateUserRequest.UserId);
            _mapper.Map(updateUserRequest, user);
            await _userDal.UpdateAsync(user);
            return _mapper.Map<UpdatedUserResponse>(user);
        }
    }
}
}
