using Business.Abstracts;
using Business.Dtos.CourseLikedByUser.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseLikedByUseresController : ControllerBase
    {
        ICourseLikedByUserService _courseLikedByUserService;
        public CourseLikedByUseresController(ICourseLikedByUserService courseLikedByUserService)
        {
            _courseLikedByUserService = courseLikedByUserService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseLikedByUserRequest createCourseLikedByUserRequest)
        {
            var result = await _courseLikedByUserService.AddAsync(createCourseLikedByUserRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseLikedByUserRequest updateCourseLikedByUserRequest)
        {
            var result = await _courseLikedByUserService.UpdateAsync(updateCourseLikedByUserRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid courseLikedByUserId)
        {
            var result = await _courseLikedByUserService.DeleteAsync(courseLikedByUserId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseLikedByUserService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid courseLikedByUserId)
        {
            var result = await _courseLikedByUserService.GetByIdAsync(courseLikedByUserId);
            return Ok(result);
        }
    }
}
