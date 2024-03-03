using Business.Abstracts;
using Business.Dtos.Course.Requests;
using Business.Dtos.SocialMediaAccount.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        ISocialMediaService _socialMediaService;
        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateSocialMediaRequest createSocialMediaRequest)
        {
            var result = await _socialMediaService.AddAsync(createSocialMediaRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSocialMediaRequest updateSocialMediaRequest)
        {
            var result = await _socialMediaService.UpdateAsync(updateSocialMediaRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteSocialMediaRequest deleteSocialMediaRequest)
        {
            var result = await _socialMediaService.DeleteAsync(deleteSocialMediaRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _socialMediaService.GetListAsync();
            return Ok(result);
        }
    }
}
