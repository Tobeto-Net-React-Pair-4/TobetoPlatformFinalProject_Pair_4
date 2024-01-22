using Business.Abstracts;
using Business.Dtos.Education.Requests;
using Business.Dtos.Instructor.Requests;
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
        public async Task<IActionResult> Delete([FromBody] DeleteEducationRequest deleteEducationRequest)
        {
            var result = await _educationService.DeleteAsync(deleteEducationRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _educationService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdEducationRequest getByIdEducationRequest)
        {
            var result = await _educationService.GetByIdAsync(getByIdEducationRequest);
            return Ok(result);
        }
    }
}
