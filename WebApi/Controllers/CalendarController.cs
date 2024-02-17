using Business.Abstracts;
using Business.Dtos.Category.Requests;
using Business.Dtos.Course.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody]CreateCalendarRequest createCalendarRequest)
        {
            var result = await _calendarService.AddAsync(createCalendarRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateCalendarRequest updateCalendarRequest)
        {
            var result = await _calendarService.UpdateAsync(updateCalendarRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid calendarId)
        {
            var result = await _calendarService.DeleteAsync(calendarId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _calendarService.GetListAsync();
            return Ok(result);
        }
    }
}
