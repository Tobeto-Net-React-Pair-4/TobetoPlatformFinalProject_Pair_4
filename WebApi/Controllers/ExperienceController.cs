using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Business.Dtos.Experience.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        IExperienceService _experinceService;
        public ExperienceController(IExperienceService experinceService)
        {
            _experinceService = experinceService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateExperienceRequest createExperinceRequest)
        {
            var result = await _experinceService.AddAsync(createExperinceRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateExperienceRequest updateExperinceRequest)
        {
            var result = await _experinceService.UpdateAsync(updateExperinceRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid experienceId)
        {
            var result = await _experinceService.DeleteAsync(experienceId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _experinceService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetListByUserId")]
        public async Task<IActionResult> GetListByUserId([FromQuery] Guid userId)
        {
            var result = await _experinceService.GetListByUserIdAsync(userId);
            return Ok(result);
        }
    }
}
