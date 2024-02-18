using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Business.Dtos.Experience.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        IExperinceService _experinceService;
        public ExperienceController(IExperinceService experinceService)
        {
            _experinceService = experinceService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateExperinceRequest createExperinceRequest)
        {
            var result = await _experinceService.AddAsync(createExperinceRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateExperinceRequest updateExperinceRequest)
        {
            var result = await _experinceService.UpdateAsync(updateExperinceRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteExperinceRequest deleteExperinceRequest)
        {
            var result = await _experinceService.DeleteAsync(deleteExperinceRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _experinceService.GetListAsync();
            return Ok(result);
        }
    }
}
