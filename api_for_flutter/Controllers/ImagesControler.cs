using api_for_flutter.Services.Images_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesControler : ControllerBase
    {
        protected readonly IImageService _imageService;
        public ImagesControler(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpPost]
        public IActionResult AddImage(IFormFile imageFile)
        {
            var res =_imageService.SaveImages(imageFile);
            return Ok(res);

        }
        [HttpPut]
        public IActionResult updateimage(int idImage,int idAds)
        {
            var res = _imageService.UpdateImages(idAds, idImage);
            return Ok(res);
        }

        [HttpDelete]
        public IActionResult DeleteImage(int idAds)
        {
            var res = _imageService.DeleteImages(idAds);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAllImagesByAds(int idAds)
        {
            var res = _imageService.GetImagesByIdAds(idAds);
            return Ok(res);
        }


        // Deals Images Controlelr EndPoint 

        [HttpPut("updateDealsImages")]
        public IActionResult updateDealsimage(int idImage, int idDeals)
        {
            var res = _imageService.UpdateDealsImages(idDeals, idImage);
            return Ok(res);
        }

        [HttpDelete("deleteDealsImages")]
        public IActionResult DeleteDealsImage(int idDeals)
        {
            var res = _imageService.DeleteDealsImages(idDeals);
            return Ok(res);
        }

        [HttpGet("getAllDealsImages")]
        public IActionResult GetAllImagesByDeals(int idDeals)
        {
            var res = _imageService.GetImagesByIdDeals(idDeals);
            return Ok(res);
        }
      /*  [HttpDelete("clear")]
        public async Task DeleteAll()
        {
             _imageService.CleanUpOrphanedImages();
        }*/


    }
}
