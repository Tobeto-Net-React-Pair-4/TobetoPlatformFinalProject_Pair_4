using Business.Abstracts;
using Business.Dtos.Exam.Requests;
using Business.Dtos.ExamQuestion.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamQuestionsController : ControllerBase
    {
        IExamQuestionService _examQuestionService;
        public ExamQuestionsController(IExamQuestionService examQuestionService)
        {
            _examQuestionService = examQuestionService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateExamQuestionRequest createExamQuestionRequest)
        {
            var result = await _examQuestionService.AddAsync(createExamQuestionRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateExamQuestionRequest updateExamQuestionRequest)
        {
            var result = await _examQuestionService.UpdateAsync(updateExamQuestionRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteExamQuestionRequest deleteExamQuestionRequest)
        {
            var result = await _examQuestionService.DeleteAsync(deleteExamQuestionRequest);
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdExamQuestionRequest getByIdExamQuestionRequest)
        {
            var result = await _examQuestionService.GetByIdAsync(getByIdExamQuestionRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _examQuestionService.GetListAsync();
            return Ok(result);
        }
    }
}
