using Business.Abstracts;
using Business.Dtos.Category.Requests;
using Business.Dtos.Course.Requests;
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
        public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
        {
            var result = await _courseService.Add(createCourseRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            var result = await _courseService.Update(updateCourseRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseRequest deleteCourseRequest)
        {
            var result = await _courseService.Delete(deleteCourseRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCourseRequest getByIdCourseRequest)
        {
            var result = await _courseService.GetById(getByIdCourseRequest);
            return Ok(result);
        }
    }
}
