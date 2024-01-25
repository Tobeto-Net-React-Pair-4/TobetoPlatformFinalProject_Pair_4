using Business.Abstracts;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserOperationClaim.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserOperationClaimRequest createUserOperationClaimRequest)
        {
            var result = await _userOperationClaimService.AddAsync(createUserOperationClaimRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userOperationClaimService.GetListAsync();
            return Ok(result);
        }
    }
}
