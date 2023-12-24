using Business.Abstracts;
using Business.Dtos.Survey.Requests;
using Business.Dtos.UserSurvey.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSurveysController : ControllerBase
    {
        IUserSurveyService _userSurveyService;
        public UserSurveysController(IUserSurveyService userSurveyService)
        {
            _userSurveyService = userSurveyService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserSurveyRequest createUserSurveyRequest)
        {
            var result = await _userSurveyService.AddAsync(createUserSurveyRequest);
            return Ok(result);
        }
        

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserSurveyRequest deleteUserSurveyRequest)
        {
            var result = await _userSurveyService.Delete(deleteUserSurveyRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userSurveyService.GetListAsync();
            return Ok(result);
        }
    }
}
