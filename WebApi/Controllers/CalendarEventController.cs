using Business.Abstracts;
using Business.Dtos.Category.Requests;
using Business.Dtos.Course.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventController : ControllerBase
    {
        ICalendarEventService _calendarEventService;
        public CalendarEventController(ICalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateCalendarEventRequest createCalendarEventRequest)
        {
            var result = await _calendarEventService.Add(createCalendarEventRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UpdateCalendarEventRequest updateCalendarEventRequest)
        {
            var result = await _calendarEventService.Update(updateCalendarEventRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteCalendarEventRequest deleteCalendarEventRequest)
        {
            var result = await _calendarEventService.Delete(deleteCalendarEventRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _calendarEventService.GetListAsync();
            return Ok(result);
        }
    }
}
