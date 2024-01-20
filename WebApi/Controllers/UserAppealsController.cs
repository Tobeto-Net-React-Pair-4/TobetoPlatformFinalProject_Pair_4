using Business.Abstracts;
using Business.Dtos.UserAppeal.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppealsController : ControllerBase
    {
        IUserAppealService _userAppealService;
        public UserAppealsController(IUserAppealService userAppealService)
        {
            _userAppealService = userAppealService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserAppealRequest createUserAppealRequest)
        {
            var result = await _userAppealService.AddAsync(createUserAppealRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userAppealService.GetListAsync();
            return Ok(result);
        }
    }// EKLENECEK DİGER SERVİCELER VAR
}
