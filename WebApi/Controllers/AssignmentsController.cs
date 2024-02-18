using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        IAssignmentService _assignmentService;
        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAssignmentRequest createAssignmentRequest)
        {
            var result = await _assignmentService.AddAsync(createAssignmentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAssignmentRequest updateAssignmentRequest)
        {
            var result = await _assignmentService.UpdateAsync(updateAssignmentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid assignmentId)
        {
            var result = await _assignmentService.DeleteAsync(assignmentId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _assignmentService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid assignmentId)
        {
            var result = await _assignmentService.GetByIdAsync(assignmentId);
            return Ok(result);
        }
    }
}
