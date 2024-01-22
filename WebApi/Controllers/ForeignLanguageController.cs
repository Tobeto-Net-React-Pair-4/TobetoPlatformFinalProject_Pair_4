using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.ForeignLanguage.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguageController : ControllerBase
    {
        IForeignLanguageService _foreignLanguageService;
        public ForeignLanguageController(IForeignLanguageService foreignLanguageService)
        {
            _foreignLanguageService = foreignLanguageService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateForeignLanguageRequest createForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.AddAsync(createForeignLanguageRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateForeignLanguageRequest updateForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.UpdateAsync(updateForeignLanguageRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteForeignLanguageRequest deleteForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.DeleteAsync(deleteForeignLanguageRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _foreignLanguageService.GetListAsync();
            return Ok(result);
        }
    }
}
