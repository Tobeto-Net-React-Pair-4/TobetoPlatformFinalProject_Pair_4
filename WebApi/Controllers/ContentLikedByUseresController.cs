using Business.Abstracts;
using Business.Dtos.ContentLikedByUser.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentLikedByUseresController : ControllerBase
    {
        IContentLikedByUserService _contentLikedByUserService;
        public ContentLikedByUseresController(IContentLikedByUserService contentLikedByUserService)
        {
            _contentLikedByUserService = contentLikedByUserService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateContentLikedByUserRequest createContentLikedByUserRequest)
        {
            var result = await _contentLikedByUserService.AddAsync(createContentLikedByUserRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateContentLikedByUserRequest updateContentLikedByUserRequest)
        {
            var result = await _contentLikedByUserService.UpdateAsync(updateContentLikedByUserRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid contentLikedByUserId)
        {
            var result = await _contentLikedByUserService.DeleteAsync(contentLikedByUserId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _contentLikedByUserService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid contentLikedByUserId)
        {
            var result = await _contentLikedByUserService.GetByIdAsync(contentLikedByUserId);
            return Ok(result);
        }
    }
}
