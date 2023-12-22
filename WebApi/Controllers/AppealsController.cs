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
        public async Task<IActionResult> Add([FromBody] CreateAppealRequest createAppealRequest)
        {
            var result = await _appealService.Add(createAppealRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAppealRequest updateAppealRequest)
        {
            var result = await _appealService.Update(updateAppealRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAppealRequest deleteAppealRequest)
        {
            var result = await _appealService.Delete(deleteAppealRequest);
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
