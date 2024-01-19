using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IMapper _mapper;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(LoginValidator))]
        public async Task<IUser> Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }


    }
}
