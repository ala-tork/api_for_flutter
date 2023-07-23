using api_for_flutter.Services.Images_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
