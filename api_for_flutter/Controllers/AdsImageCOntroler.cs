using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Services.AdsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsImageCOntroler : ControllerBase
    {
        private readonly Iservices _services;
        
        public AdsImageCOntroler(Iservices services , ApplicationDBContext context)
        {
            _services = services;
        }


        [HttpPost("CreateAds")]
        public IActionResult CreateAd([FromForm] CreateAds adModel, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {

                    string imageUrl = SaveImageAndGetUrl(imageFile);

                    adModel.ImagePrinciple = imageUrl;

                    _services.CreateAdd(adModel);

                    return Ok(adModel);
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


    }
}

