using Business.Abstracts;
using Business.Dtos.Category.Requests;
using Business.Dtos.Course.Requests;
using Business.Dtos.UserCourse.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseRequest createCourseRequest)
        {
            var result = await _courseService.AddAsync(createCourseRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            var result = await _courseService.UpdateAsync(updateCourseRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid courseId)
        {
            var result = await _courseService.DeleteAsync(courseId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid courseId)
        {
            var result = await _courseService.GetByIdAsync(courseId);
            return Ok(result);
        }
        [HttpGet("GetListByUserId")]
        public async Task<IActionResult> GetListByUserId([FromQuery] Guid userId)
        {
            var result = await _courseService.GetListByUserIdAsync(userId);
            return Ok(result);
        }
        [HttpPost("AssignCourseToUser")]
        public async Task<IActionResult> AssignCourseToUser([FromBody] CreateUserCourseRequest createUserCourseRequest)
        {
            var result = await _courseService.AssignCourseToUserAsync(createUserCourseRequest);
            return Ok(result);
        }
    }
}
