using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Liked.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        ILikeService _likedService;
        public LikesController(ILikeService likedService)
        {
            _likedService = likedService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateLikeRequest createLikedRequest)
        {
            var result = await _likedService.AddAsync(createLikedRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLikeRequest updateLikedRequest)
        {
            var result = await _likedService.UpdateAsync(updateLikedRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid likeId)
        {
            var result = await _likedService.DeleteAsync(likeId);
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid likeId)
        {
            var result = await _likedService.GetByIdAsync(likeId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _likedService.GetListAsync();
            return Ok(result);
        }
    }
}
