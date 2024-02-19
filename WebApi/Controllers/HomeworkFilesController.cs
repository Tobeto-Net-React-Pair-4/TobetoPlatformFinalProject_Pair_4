using Business.Abstracts;
using Business.Dtos.HomeworkFile.Requests;
using Business.Dtos.QuestionAnswer.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkFilesController : ControllerBase
    {
        IHomeworkFileService _homeworkFileService;
        public HomeworkFilesController(IHomeworkFileService homeworkFileService)
        {
            _homeworkFileService = homeworkFileService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateHomeworkFileRequest createHomeworkFileRequest)
        {
            var result = await _homeworkFileService.AddAsync(createHomeworkFileRequest);
            return Ok(result);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Guid homeworkFileId)
        {
            var result = await _homeworkFileService.DeleteAsync(homeworkFileId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _homeworkFileService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetListByIdAsync([FromQuery] Guid homeworkId)
        {
            var result = await _homeworkFileService.GetListByHomeworkIdAsync(homeworkId);
            return Ok(result);
        }
    }
}
