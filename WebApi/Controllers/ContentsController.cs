using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Course.Requests;
using Business.Dtos.ExamQuestion.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        IContentService _contentService;
        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateContentRequest createContentRequest)
        {
            var result = await _contentService.AddAsync(createContentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateContentRequest updateContentRequest)
        {
            var result = await _contentService.UpdateAsync(updateContentRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteContentRequest deleteContentRequest)
        {
            var result = await _contentService.DeleteAsync(deleteContentRequest);
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetContentRequest getContentRequest)
        {
            var result = await _contentService.GetByIdAsync(getContentRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _contentService.GetListAsync();
            return Ok(result);
        }
    }
}
