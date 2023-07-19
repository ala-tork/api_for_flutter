using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.AdsServices;
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
        public AdsController(Iservices iservices ,ApplicationDBContext context )
        {
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

       /* [HttpPost("createAds")]
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

        }*/

        [HttpPost("CreateAds")]
        public IActionResult CreateAd([FromForm] CreateAds adModel, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    if (!adModel.listFeatures_FeatureValues.IsNullOrEmpty())
                    {
                        string imageUrl = SaveImageAndGetUrl(imageFile);

                        adModel.ImagePrinciple = imageUrl;

                        _iservices.CreateAdd(adModel);

                        return Ok(adModel);

                    }
                    adModel.listFeatures_FeatureValues.Add(new Models.ListFeatures_FeatureValue { FeatureId = 1, FeatureValueId = 3 });
                    return BadRequest(adModel);

                }
                else
                {
                    return BadRequest("Image file not provided.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private string SaveImageAndGetUrl(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return "https://localhost:7058/Assets/images/" + uniqueFileName;
        }


        [HttpPost("test")]
        public async Task<IActionResult> test(CreateAds adModel)
        {
            var res = await _iservices.ShowME(adModel);
            return Ok(res);
            
        }
    }
}
