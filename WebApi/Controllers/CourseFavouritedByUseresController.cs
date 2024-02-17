using Business.Abstracts;
using Business.Dtos.CourseFavouritedByUser.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseFavouritedByUseresController : ControllerBase
    {
        ICourseFavouritedByUserService _courseFavouritedByUserService;
        public CourseFavouritedByUseresController(ICourseFavouritedByUserService courseFavouritedByUserService)
        {
            _courseFavouritedByUserService = courseFavouritedByUserService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseFavouritedByUserRequest createCourseFavouritedByUserRequest)
        {
            var result = await _courseFavouritedByUserService.AddAsync(createCourseFavouritedByUserRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseFavouritedByUserRequest updateCourseFavouritedByUserRequest)
        {
            var result = await _courseFavouritedByUserService.UpdateAsync(updateCourseFavouritedByUserRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid courseFavouritedByUserId)
        {
            var result = await _courseFavouritedByUserService.DeleteAsync(courseFavouritedByUserId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseFavouritedByUserService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid courseFavouritedByUserId)
        {
            var result = await _courseFavouritedByUserService.GetByIdAsync(courseFavouritedByUserId);
            return Ok(result);
        }
    }
}
