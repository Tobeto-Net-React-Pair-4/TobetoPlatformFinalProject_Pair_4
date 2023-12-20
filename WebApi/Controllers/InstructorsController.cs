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
        public async Task<IActionResult> Add([FromBody] CreateInstructorRequest createInstructorRequest)
        {
            var result = await _instructorService.Add(createInstructorRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.Update(updateInstructorRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInstructorRequest deleteInstructorRequest)
        {
            var result = await _instructorService.Delete(deleteInstructorRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _instructorService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdInstructorRequest getByIdInstructorRequest)
        {
            var result = await _instructorService.GetById(getByIdInstructorRequest);
            return Ok(result);
        }
    }
}
