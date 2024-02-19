using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Exam.Requests;
using Business.Dtos.Exam.Responses;
using Business.Dtos.UserExam.Requests;
using Business.Dtos.UserExam.Responses;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateExamRequest createExamRequest)
        {
            var result = await _examService.AddAsync(createExamRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateExamRequest updateExamRequest)
        {
            var result = await _examService.UpdateAsync(updateExamRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid examId)
        {
            var result = await _examService.DeleteAsync(examId);
            return Ok(result);
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid examId)
        {
            var result = await _examService.GetByIdAsync(examId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _examService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("GetListByUserId")]
        public async Task<IActionResult> GetListByUserId([FromQuery] Guid userId)
        {
            var result = await _examService.GetListByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpPost("AssignExamToUser")]
        public async Task<IActionResult> AssignExamToUser([FromBody] CreateUserExamRequest createUserExamRequest)
        {
            var result = await _examService.AssignExamToUserAsync(createUserExamRequest);
            return Ok(result);
        }
    }
}
