using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.UserAnnouncement.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnnouncementsController : ControllerBase
    {
        IUserAnnouncementService _userAnnouncementService;
        public UserAnnouncementsController(IUserAnnouncementService userAnnouncementService)
        {
            _userAnnouncementService = userAnnouncementService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserAnnouncementRequest createUserAnnouncementRequest)
        {
            var result = await _userAnnouncementService.AddAsync(createUserAnnouncementRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserAnnouncementRequest updateUserAnnouncementRequest)
        {
            var result = await _userAnnouncementService.UpdateAsync(updateUserAnnouncementRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteUserAnnouncementRequest deleteUserAnnouncementRequest)
        {
            var result = await _userAnnouncementService.DeleteAsync(deleteUserAnnouncementRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userAnnouncementService.GetListAsync();
            return Ok(result);
        }
    }
}
