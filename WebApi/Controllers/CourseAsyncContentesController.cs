using Business.Abstracts;
using Business.Dtos.CourseAsyncContent.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAsyncContentesController : ControllerBase
    {
        ICourseAsyncContentService _courseAsyncContentService;
        public CourseAsyncContentesController(ICourseAsyncContentService courseAsyncContentService)
        {
            _courseAsyncContentService = courseAsyncContentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCourseAsyncContentRequest createCourseAsyncContentRequest)
        {
            var result = await _courseAsyncContentService.AddAsync(createCourseAsyncContentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseAsyncContentRequest updateCourseAsyncContentRequest)
        {
            var result = await _courseAsyncContentService.UpdateAsync(updateCourseAsyncContentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid courseAsyncContentId)
        {
            var result = await _courseAsyncContentService.DeleteAsync(courseAsyncContentId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseAsyncContentService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid courseAsyncContentId)
        {
            var result = await _courseAsyncContentService.GetByIdAsync(courseAsyncContentId);
            return Ok(result);
        }
    }
}
