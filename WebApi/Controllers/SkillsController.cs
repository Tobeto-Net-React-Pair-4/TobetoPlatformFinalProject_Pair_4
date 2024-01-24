using Business.Abstracts;
using Business.Dtos.Skill.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ISkillService _SkillService;
        public SkillsController(ISkillService SkillService)
        {
            _SkillService = SkillService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateSkillRequest createSkillRequest)
        {
            var result = await _SkillService.AddAsync(createSkillRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSkillRequest updateSkillRequest)
        {
            var result = await _SkillService.UpdateAsync(updateSkillRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSkillRequest deleteSkillRequest)
        {
            var result = await _SkillService.DeleteAsync(deleteSkillRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _SkillService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] GetByIdSkillRequest getByIdSkillRequest)
        {
            var result = await _SkillService.GetByIdAsync(getByIdSkillRequest);
            return Ok(result);
        }
    }
}
