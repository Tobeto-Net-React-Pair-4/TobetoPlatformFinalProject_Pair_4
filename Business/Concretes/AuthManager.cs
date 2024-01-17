using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.User.Requests;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IMapper _mapper;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public Task<User> Login(UserLoginRequest userLoginRequest)
        {
            throw new NotImplementedException();
        }

        Task IAuthService.UserExists(string email)
        {
            throw new NotImplementedException();
        }

        AccessToken IAuthService.CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
