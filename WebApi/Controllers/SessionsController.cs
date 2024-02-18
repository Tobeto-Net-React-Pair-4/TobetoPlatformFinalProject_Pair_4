using Business.Abstracts;
using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateSessionRequest createSessionRequest)
        {
            var result = await _sessionService.AddAsync(createSessionRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _sessionService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid sessionId)
        {
            var result = await _sessionService.GetByIdAsync(sessionId);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSessionRequest updateSessionRequest)
        {
            var result = await _sessionService.UpdateAsync(updateSessionRequest);
            return Ok(result);
        }

        [HttpGet("GetListByInstructorId")]
        public async Task<IActionResult> GetListByInstructorId([FromQuery]  Guid instructorId)
        {
            var result = await _sessionService.GetListByInstructorIdAsync(instructorId);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid sessionId)
        {
            var result = await _sessionService.DeleteAsync(sessionId);
            return Ok(result);
        }
    }
}
