using Business.Abstracts;
using Business.Dtos.OperationClaim.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimRequest operationClaimRequest)
        {
            var result = await _operationClaimService.AddAsync(operationClaimRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _operationClaimService.GetListAsync();
            return Ok(result);
        }

    }
}
