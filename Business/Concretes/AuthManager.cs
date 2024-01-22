using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Auth.Requests;
using Business.Dtos.User.Requests;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concretes;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IMapper _mapper;
        ITokenHelper _tokenHelper;
        AuthBusinessRules _authBusinessRules;
        

        public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }

        public AccessToken CreateAccesToken(IUser user)
        {
            var claims = _userService.GetClaims(user);
            var accesToken = _tokenHelper.CreateToken(user, claims);
            return accesToken;
        }

        [ValidationAspect(typeof(LoginValidator))]
        public async Task<IUser> Login(UserLoginRequest userLoginRequest)
        {
            return await _authBusinessRules.UserToCheck(userLoginRequest);
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public async Task<IUser> Register(UserRegisterRequest userRegisterRequest)
        {
            await _authBusinessRules.UserExists(userRegisterRequest.Email);
            HashingHelper.CreatePasswordHash(userRegisterRequest.Password, out userRegisterRequest.passwordHash, out userRegisterRequest.passwordSalt);
            User user = _mapper.Map<User>(userRegisterRequest);
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);
            await _userService.AddAsync(createUserRequest);
            return user;
        }
    }


 }
