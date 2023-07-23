using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Services.AdsServices;
using api_for_flutter.Services.Images_Services;
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
        private readonly IImageService _imageService;

        public AdsImageCOntroler(Iservices services , ApplicationDBContext context, IImageService imageService)
        {
            _imageService = imageService;
            _services = services;
        }


        /* [HttpPost("CreateAds")]
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
         }*/

      /*  [HttpPost("testmultyimages")]
        public IActionResult TestMultyImages(List<IFormFile> Allimages)
        {
            if (Allimages == null || Allimages.Count == 0)
            {
                return BadRequest("Image files not provided.");
            }

            try
            {
                foreach (var item in Allimages)
                {
                    _imageService.SaveImages(item, 1);
                }

                return Ok("Successfully saved all images.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the image saving process.
                return StatusCode(500, "An error occurred while saving the images: " + ex.Message);
            }
        }*/

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

