using Business.Abstracts;
using Business.Dtos.File.Requests;
using Business.Dtos.File.Responses;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        IFileService _fileService;
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateFileRequest createFileRequest)
        {
            var result = await _fileService.AddAsync(createFileRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateFileRequest updateFileRequest)
        {
            var result = await _fileService.UpdateAsync(updateFileRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid fileId)
        {
            var result = await _fileService.DeleteAsync(fileId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _fileService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid fileId)
        {
            var result = await _fileService.GetByIdAsync(fileId);
            return Ok(result);
        }
        [HttpGet("GetListByHomeworkId")]
        public async Task<IActionResult> GetListByHomeworkId([FromQuery] Guid homeworkId)
        {
            var result = await _fileService.GetListByHomeworkIdAsync(homeworkId);
            return Ok(result);
        }
    }
}
