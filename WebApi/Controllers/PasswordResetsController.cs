using Business.Abstracts;
using Business.Dtos.PasswordReset.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetsController : ControllerBase
    {
        IPasswordResetService _passwordResetService;
        public PasswordResetsController(IPasswordResetService passwordResetService)
        {
            _passwordResetService = passwordResetService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreatePasswordResetRequest createPasswordResetRequest)
        {
            var result = await _passwordResetService.AddAsync(createPasswordResetRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePasswordResetRequest updatePasswordResetRequest)
        {
            var result = await _passwordResetService.UpdateAsync(updatePasswordResetRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid passwordResetId)
        {
            var result = await _passwordResetService.DeleteAsync(passwordResetId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _passwordResetService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid passwordResetId)
        {
            var result = await _passwordResetService.GetByIdAsync(passwordResetId);
            return Ok(result);
        }
    }
}
