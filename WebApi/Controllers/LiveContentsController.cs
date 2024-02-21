using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.LiveContent.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveContentsController : ControllerBase
    {
        ILiveContentService _liveContentService;
        public LiveContentsController(ILiveContentService liveContentService)
        {
            _liveContentService = liveContentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateLiveContentRequest createLiveContentRequest)
        {
            var result = await _liveContentService.AddAsync(createLiveContentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateLiveContentRequest updateLiveContentRequest)
        {
            var result = await _liveContentService.UpdateAsync(updateLiveContentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid liveContentId)
        {
            var result = await _liveContentService.DeleteAsync(liveContentId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _liveContentService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid liveContentId)
        {
            var result = await _liveContentService.GetByIdAsync(liveContentId);
            return Ok(result);
        }


        [HttpGet("GetListByCourseId")]
        public async Task<IActionResult> GetListByCourseIdAsync([FromQuery] Guid courseId)
        {
            var result = await _liveContentService.GetListLiveContentByCourseIdAsync(courseId);
            return Ok(result);
        }

        [HttpPost("AssignContentAsync")]
        public async Task<IActionResult> AssignLiveContentAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest)
        {
            var result = await _liveContentService.AssignLiveContentAsync(createCourseLiveContentRequest);
            return Ok(result);
        }
    }
}

