using Business.Abstracts;
using Business.Dtos.UserSkill.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillsController : ControllerBase
    {
        IUserSkillService _userSkillService;
        public UserSkillsController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserSkillRequest createUserSkillRequest)
        {
            var result = await _userSkillService.AddAsync(createUserSkillRequest);
            return Ok(result);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserSkillRequest deleteUserSkillRequest)
        {
            var result = await _userSkillService.DeleteAsync(deleteUserSkillRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userSkillService.GetListAsync();
            return Ok(result);
        }
    }
}
