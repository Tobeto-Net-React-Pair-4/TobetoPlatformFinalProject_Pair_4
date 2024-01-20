using Business.Abstracts;
using Business.Dtos.ExamQuestion.Requests;
using Business.Dtos.QuestionAnswer.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAnswersController : ControllerBase
    {
        IQuestionAnswerService _questionAnswerService;
        public QuestionAnswersController(IQuestionAnswerService questionAnswerService)
        {
            _questionAnswerService = questionAnswerService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateQuestionAnswerRequest createQuestionAnswerRequest)
        {
            var result = await _questionAnswerService.AddAsync(createQuestionAnswerRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionAnswerRequest updateQuestionAnswerRequest)
        {
            var result = await _questionAnswerService.UpdateAsync(updateQuestionAnswerRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteQuestionAnswerRequest deleteQuestionAnswerRequest)
        {
            var result = await _questionAnswerService.DeleteAsync(deleteQuestionAnswerRequest);
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdQuestionAnswerRequest getByIdQuestionAnswerRequest)
        { 
            var result = await _questionAnswerService.GetByIdAsync(getByIdQuestionAnswerRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _questionAnswerService.GetListAsync();
            return Ok(result);
        }
    }
}
