using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Appeal.Requests;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserCourse.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAnnouncementRequest createAnnouncementRequest)
        {
            var result = await _announcementService.AddAsync(createAnnouncementRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            var result = await _announcementService.UpdateAsync(updateAnnouncementRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid announcementId)
        {
            var result = await _announcementService.DeleteAsync(announcementId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _announcementService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetListByUserId")]
        public async Task<IActionResult> GetListByUserId([FromQuery] Guid userId)
        {
            var result = await _announcementService.GetListByUserIdAsync(userId);
            return Ok(result);
        }
        [HttpPost("AssignAnnouncementToUser")]
        public async Task<IActionResult> AssignAnnouncementToUserAsync([FromBody] CreateUserAnnouncementRequest createUserAnnouncementRequest)
        {
            var result = await _announcementService.AssignAnnouncementToUserAsync(createUserAnnouncementRequest);
            return Ok(result);
        }
    }
}
