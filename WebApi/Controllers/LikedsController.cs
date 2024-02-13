using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Liked.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedsController : ControllerBase
    {
        ILikedService _likedService;
        public LikedsController(ILikedService likedService)
        {
            _likedService = likedService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateLikedRequest createLikedRequest)
        {
            var result = await _likedService.AddAsync(createLikedRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLikedRequest updateLikedRequest)
        {
            var result = await _likedService.UpdateAsync(updateLikedRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLikedRequest deleteLikedRequest)
        {
            var result = await _likedService.DeleteAsync(deleteLikedRequest);
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetLikedRequest getLikedRequest)
        {
            var result = await _likedService.GetByIdAsync(getLikedRequest);
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
