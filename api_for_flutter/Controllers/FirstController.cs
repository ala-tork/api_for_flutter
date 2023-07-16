using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Services.AdsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        private readonly Iservices _iservices;
        private readonly ApplicationDBContext _context;
        public FirstController(Iservices iservices ,ApplicationDBContext context)
        {
            _context = context;
            _iservices = iservices;
        }



        [HttpGet("ads")]
        public IActionResult GetAllAds() {
            try
            {
                var data = _iservices.GetAds().ToList();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet("ShowMore")]
        public IActionResult ShowMore(int page) {
            var data = _iservices.ofset(page).ToList();
            return Ok(data);
        }
        [HttpGet("NbrAds")]
        public IActionResult NbrAds()
        {
            return Ok(_iservices.NbrAds());
        }

        [HttpGet("/Ad/{id}")]
        public IActionResult GetAdById(int id)
        {
            var ad = _iservices.GetAdById(id);

            if (ad == null)
            {
                return NotFound();
            }

            return Ok(ad);
        }

        [HttpPost("createAds")]
        public async Task<IActionResult> CreateAds(CreateAds ad)
        {
            try
            {
                var createdAd = await _iservices.CreateAdd(ad);
                return Ok(createdAd);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the ad.");
            }

        }
    }
}
