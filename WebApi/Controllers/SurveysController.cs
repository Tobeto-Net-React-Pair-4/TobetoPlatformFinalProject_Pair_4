using Business.Abstracts;
using Business.Dtos.Survey.Requests;
using Business.Dtos.User.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        ISurveyService _surveyService;
        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;  
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateSurveyRequest createSurveyRequest)
        {
            var result = await _surveyService.AddAsync(createSurveyRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateSurveyRequest updateSurveyRequest)
        {
            var result = await _surveyService.UpdateAsync(updateSurveyRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteSurveyRequest deleteSurveyRequest)
        {
            var result = await _surveyService.DeleteAsync(deleteSurveyRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _surveyService.GetListAsync();
            return Ok(result);
        }
    }
}
