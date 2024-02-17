using Business.Abstracts;
using Business.Dtos.Category.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            var result = await _categoryService.AddAsync(createCategoryRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _categoryService.UpdateAsync(updateCategoryRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _categoryService.DeleteAsync(deleteCategoryRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _categoryService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid categoryId)
        {
            var result = await _categoryService.GetByIdAsync(categoryId);
            return Ok(result);
        }
    }
}
