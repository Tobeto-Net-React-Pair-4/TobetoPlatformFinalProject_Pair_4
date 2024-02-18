using Business.Abstracts;
using Business.Dtos.Homework.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        public HomeworksController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateHomeworkRequest homeworkRequest)
        {
            var result = await _homeworkService.AddAsync(homeworkRequest);
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] Guid homeworkId)
        {
            var result = await _homeworkService.GetByIdAsync(homeworkId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHomeworkRequest updateHomeworkRequest)
        {
            var result = await _homeworkService.UpdateAsync(updateHomeworkRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _homeworkService.GetListAsync();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid homeworkId)
        {
            var result = await _homeworkService.DeleteAsync(homeworkId);
            return Ok(result);
        }
    }
}
