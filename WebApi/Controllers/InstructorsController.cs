using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Business.Dtos.Instructor.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateInstructorRequest createInstructorRequest)
        {
            var result = await _instructorService.AddAsync(createInstructorRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.UpdateAsync(updateInstructorRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid instructorId)
        {
            var result = await _instructorService.DeleteAsync(instructorId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _instructorService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid instructorId)
        {
            var result = await _instructorService.GetByIdAsync(instructorId);
            return Ok(result);
        }
    }
}
