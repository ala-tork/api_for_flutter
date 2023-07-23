using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.AdsServices;
using api_for_flutter.Services.Images_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace api_for_flutter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly Iservices _iservices;
        private readonly IImageService _imageService;
        public AdsController(Iservices iservices ,ApplicationDBContext context ,IImageService imageService)
        {
            _imageService= imageService;
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

        [HttpPost("CreateAds")]
        public async  Task<IActionResult> CreateAd([FromForm] CreateAds adModel)
        {
            if (ModelState.IsValid )
            {
                    var x = await _iservices.CreateAdd(adModel);
                    return Ok(x);
            }
            else
            {
                return BadRequest();
            }
        }


    


    //[HttpPost("test")]
    //    public async Task<IActionResult> test(CreateAds adModel)
    //    {
    //        var res = await _iservices.ShowME(adModel);
    //        return Ok(res);
            
    //    }
    }
}
