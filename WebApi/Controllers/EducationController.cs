using Business.Abstracts;
using Business.Dtos.Education.Requests;
using Business.Dtos.Instructor.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateEducationRequest createEducationRequest)
        {
            var result = await _educationService.AddAsync(createEducationRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEducationRequest updateEducationRequest)
        {
            var result = await _educationService.UpdateAsync(updateEducationRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid educationId)
        {
            var result = await _educationService.DeleteAsync(educationId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _educationService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid educationId)
        {
            var result = await _educationService.GetByIdAsync(educationId);
            return Ok(result);
        }
    }
}
