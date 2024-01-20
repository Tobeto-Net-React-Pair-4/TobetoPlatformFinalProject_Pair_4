using Business.Abstracts;
using Business.Dtos.Appeal.Requests;
using Business.Dtos.Instructor.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppealsController : ControllerBase
    {
        IAppealService _appealService;
        public AppealsController(IAppealService appealService)
        {
            _appealService = appealService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAppealRequest createAppealRequest)
        {
            var result = await _appealService.AddAsync(createAppealRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAppealRequest updateAppealRequest)
        {
            var result = await _appealService.UpdateAsync(updateAppealRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAppealRequest deleteAppealRequest)
        {
            var result = await _appealService.DeleteAsync(deleteAppealRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _appealService.GetListAsync();
            return Ok(result);
        }
    }
}
