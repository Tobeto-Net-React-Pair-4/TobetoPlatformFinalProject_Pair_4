using Business.Abstracts;
using Business.Dtos.Exam.Requests;
using Business.Dtos.UserExam.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExamsController : ControllerBase
    {
        IUserExamService _userExamService;
        public UserExamsController(IUserExamService userExamService)
        {
            _userExamService = userExamService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserExamRequest createUserExamRequest)
        {
            var result = await _userExamService.AddAsync(createUserExamRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserExamRequest deleteUserExamRequest)
        {
            var result = await _userExamService.DeleteAsync(deleteUserExamRequest);
            return Ok(result);
        }

        [HttpPost("Get")]
        public async Task<IActionResult> Get([FromQuery] GetUserExamRequest getUserExamRequest)
        {
            var result = await _userExamService.GetAsync(getUserExamRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userExamService.GetListAsync();
            return Ok(result);
        }
    }
}
