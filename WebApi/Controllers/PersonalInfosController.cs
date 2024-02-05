using Business.Abstracts;
using Business.Dtos.PersonalInfo.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfosController : ControllerBase
    {
        IPersonalInfoService _personalInfoService;
        public PersonalInfosController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatePersonalInfoRequest createPersonalInfoRequest)
        {
            var result = await _personalInfoService.AddAsync(createPersonalInfoRequest);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList()
        {
            var result = await _personalInfoService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] GetPersonalInfoRequest getPersonalInfoRequest)
        {
            var result = await _personalInfoService.GetByIdAsync(getPersonalInfoRequest);
            return Ok(result);
        }
        [HttpGet("getbyuserid")]
        public async Task<IActionResult> GetUserId([FromQuery] GetPersonalInfoRequest getPersonalInfoRequest)
        {
            var result = await _personalInfoService.GetByUserIdAsync(getPersonalInfoRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeletePersonalInfoRequest deletePersonalInfoRequest)
        {
            var result = await _personalInfoService.DeleteAsync(deletePersonalInfoRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePersonalInfoRequest updatePersonalInfoRequest)
        {
            var result = await _personalInfoService.UpdateAsync(updatePersonalInfoRequest);
            return Ok(result);
        }
    }
}
