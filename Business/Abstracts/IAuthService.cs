using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.User.Requests;
using Core.Utilities.Security.JWT;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<User> Register(UserRegisterRequest userRegisterRequest);
        Task<User> Login(UserLoginRequest userLoginRequest);
        Task UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
