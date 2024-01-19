using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Business.Dtos.User.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await _userService.Add(createUserRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.Update(updateUserRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest deleteUserRequest)
        {
            var result = await _userService.Delete(deleteUserRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdUserRequest getByIdUserRequest)
        {
            var result = await _userService.GetByIdAsync(getByIdUserRequest);
            return Ok(result);
        }
    }
}

