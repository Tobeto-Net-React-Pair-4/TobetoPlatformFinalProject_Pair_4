using Business.Abstracts;
using Business.Dtos.Favourite.Requests;
using Business.Dtos.Liked.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateFavouriteRequest createFavouriteRequest)
        {
            var result = await _favouriteService.AddAsync(createFavouriteRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateFavouriteRequest updateFavouriteRequest)
        {
            var result = await _favouriteService.UpdateAsync(updateFavouriteRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteFavouriteRequest deleteFavouriteRequest)
        {
            var result = await _favouriteService.DeleteAsync(deleteFavouriteRequest);
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetFavouriteRequest getFavouriteRequest)
        {
            var result = await _favouriteService.GetByIdAsync(getFavouriteRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _favouriteService.GetListAsync();
            return Ok(result);
        }
    }
}
