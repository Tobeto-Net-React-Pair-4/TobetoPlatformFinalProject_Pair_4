using Business.Dtos.Auth.Requests;
using Core.Entities;
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
        //IDataResult<User> Login(UserForLoginDto userForLoginDto);
        Task<IUser> Login(LoginRequest loginRequest);
    }
}
