using Business.Abstracts;
using Business.Dtos.Auth.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var userLogin = await _authService.Login(userLoginRequest);
            var result=_authService.CreateAccesToken(userLogin);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterRequest userRegisterRequest)
        {
            var userRegister = await _authService.Register(userRegisterRequest);
            var result = _authService.CreateAccesToken(userRegister);
            return Ok(result);
        }
    }
}
