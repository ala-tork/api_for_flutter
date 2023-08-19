using api_for_flutter.Models.WishListModel;
using api_for_flutter.Services.WishListServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api_for_flutter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWishList( CreateWishList createWishList)
        {
            try
            {
                var newWishList = await _wishListService.AddWishList(createWishList);
                return Ok(newWishList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishList(int id)
        {
            try
            {
                var deletedWishList = await _wishListService.DeleteWishList(id);
                return Ok(deletedWishList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishListById(int id)
        {
            try
            {
                var wishList = await _wishListService.GetWishListById(id);
                if (wishList == null)
                    return NotFound();

                return Ok(wishList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GEtWishListByUser/{iduser}")]
        public async Task<IActionResult> GEtWishListByUser(int iduser, int page =0, int pageSize =4)
        {
            try
            {
                var res = await _wishListService.GetWishListByIdUser(iduser, page, pageSize);
                var nbitems = _wishListService.NbrAdsByIdUser(iduser);
                return Ok(new{
                    res=res,
                    nbitems=nbitems
                });

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("WishlistByUser_ad")]
        public async Task<IActionResult> GetWishListByIdUserIdAd([FromQuery] int userId, [FromQuery] int adId)
        {
            try
            {
                var wishList = await _wishListService.GetWishListByIdUserIdAd(userId, adId);
                if (wishList == null)
                    return NotFound();

                return Ok(wishList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("WishlistByUser_deal")]
        public async Task<IActionResult> GetWishListByIdUserIdDeal([FromQuery] int userId, [FromQuery] int dealId)
        {
            try
            {
                var wishList = await _wishListService.GetWishListByIdUserIdDeal(userId, dealId);
                if (wishList == null)
                    return NotFound();

                return Ok(wishList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
