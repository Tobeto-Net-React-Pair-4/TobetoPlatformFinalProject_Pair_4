using Business.Abstracts;
using Business.Dtos.Certificate.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        ICertificateService _certificateService;
        public CertificatesController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCertificateRequest createCertificateRequest)
        {
            var result = await _certificateService.AddAsync(createCertificateRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCertificateRequest updateCertificateRequest)
        {
            var result = await _certificateService.UpdateAsync(updateCertificateRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCertificateRequest deleteCertificateRequest)
        {
            var result = await _certificateService.DeleteAsync(deleteCertificateRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _certificateService.GetListAsync();
            return Ok(result);
        }

    }
}
