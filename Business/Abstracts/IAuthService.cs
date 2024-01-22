using Business.Dtos.Auth.Requests;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        AccessToken CreateAccesToken(IUser user);
        Task<IUser> Login(UserLoginRequest userLoginRequest);
        Task<IUser> Register(UserRegisterRequest userRegisterRequest);
    }
}
