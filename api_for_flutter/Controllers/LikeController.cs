using api_for_flutter.Models.LikesPublicationModel;
using api_for_flutter.Services.LikeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        // POST: api/Like
        [HttpPost]
        public async Task<IActionResult> AddLike(CreateLikeModel createlike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newLike = await _likeService.AddLike(createlike);
            return CreatedAtAction(nameof(GetLikeById), new { id = newLike.IdLP }, newLike);
        }

        // DELETE: api/Like/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var like = await _likeService.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }

            await _likeService.DeleteLike(id);
            return Ok(like);
        }

        // GET: api/Like/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLikeById(int id)
        {
            var like = await _likeService.GetLikeById(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // GET: api/Like/ByAd/5
        [HttpGet("ByAd/{id}")]
        public async Task<IActionResult> GetLikeByAdId(int id)
        {
            var like = await _likeService.GetLikeByIdAd(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // GET: api/Like/ByAd
        [HttpGet("ByAd")]
        public async Task<IActionResult> GetLikeByAds()
        {
            var like = await _likeService.GetLikeByAds();
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // GET: api/Like/ByDeal/5
        [HttpGet("ByDeal/{id}")]
        public async Task<IActionResult> GetLikeByDealId(int id)
        {
            var like = await _likeService.GetLikeByIdDeal(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // GET: api/Like/ByDeal
        [HttpGet("ByDeal")]
        public async Task<IActionResult> GetLikeByDeal(int id)
        {
            var like = await _likeService.GetLikeByDeals();
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }



        // GET: api/like/ByUserAndDeal
        [HttpGet("ByUserAndDeal/{idUser}/{idDeal}")]
        public async Task<IActionResult> GetLikeByIdUserAndIdDeal(int idUser, int idDeal)
        {
            var like = await _likeService.GetLikeByIdUserIdDeal(idUser,idDeal);
            var nbLike = await _likeService.GetLikeByIdDeal(idDeal);

            var likeInfo = new
            {
                NbLike = nbLike.Count(),
                Like = like
            };

            return Ok(likeInfo);
        }

        // GET: api/like/ByUserAndAd
        [HttpGet("ByUserAndAd/{idUser}/{idAd}")]
        public async Task<IActionResult> GetLikeByIdUserAndIdAd(int idUser, int idAd)
        {
            var like = await _likeService.GetLikeByIdUserIdAd(idUser,idAd);
            var nbLike = await _likeService.GetLikeByIdAd(idAd);

            var likeInfo = new
            {
                NbLike = nbLike.Count(),
                Like = like
            };

            return Ok(likeInfo);
        }


    }
}
