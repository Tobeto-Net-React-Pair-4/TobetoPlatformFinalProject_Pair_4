using Business.Abstracts;
using Business.Dtos.AsyncContent.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncContentesController : ControllerBase
    {
        IAsyncContentService _asyncContentService;
        public AsyncContentesController(IAsyncContentService asyncContentService)
        {
            _asyncContentService = asyncContentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAsyncContentRequest createAsyncContentRequest)
        {
            var result = await _asyncContentService.AddAsync(createAsyncContentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAsyncContentRequest updateAsyncContentRequest)
        {
            var result = await _asyncContentService.UpdateAsync(updateAsyncContentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid categoryId)
        {
            var result = await _asyncContentService.DeleteAsync(categoryId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _asyncContentService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid categoryId)
        {
            var result = await _asyncContentService.GetByIdAsync(categoryId);
            return Ok(result);
        }
    }
}
