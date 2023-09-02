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

        [HttpDelete("IdImage")]
        public IActionResult DeleteImages(int idImage)
        {
            var res = _imageService.DeleteImages(idImage);
            return Ok(res);
        }


        [HttpPut]
        public IActionResult updateimage(int idImage,int idAds)
        {
            var res = _imageService.UpdateImages(idAds, idImage);
            return Ok(res);
        }

        [HttpDelete]
        public IActionResult DeleteAdImages(int idAds)
        {
            var res = _imageService.DeleteAdsImages(idAds);
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
            var updatedImage = _imageService.UpdateDealsImages(idDeals, idImage);
            if (updatedImage != null)
            {
                return Ok(updatedImage);
            }
            else
            {
                return NotFound();
            }
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

        /** Prize Images */

        [HttpPut("updateTaskImage")]
        public async Task<IActionResult> UpdatePrizeImage(int idPrize, int idImage)
        {
            var res = await _imageService.UpdateTaskImage(idPrize, idImage);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("deletePrizeImages")]
        public async Task<IActionResult> DeletePrizeImages(int idPrize)
        {
            var res = await _imageService.DeletePrizeImages(idPrize);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("getPrizeImage")]
        public async Task<IActionResult> GetPrizeImage(int idPrize)
        {
            var res = await _imageService.GetPrizeImage(idPrize);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }


        // Product Images Controlelr EndPoint 

        [HttpPut("updateProductImages")]
        public async  Task<IActionResult> updateProductimage(int idImage, int idProduct)
        {
            var updatedImage = await _imageService.UpdateProductImages(idProduct, idImage);
            if (updatedImage != null)
            {
                return Ok(updatedImage);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("deleteProductImages")]
        public IActionResult DeleteProductImage(int idProduct)
        {
            var res = _imageService.DeleteProductImages(idProduct);
            return Ok(res);
        }

        [HttpGet("getAllProductImages")]
        public IActionResult GetAllImagesByProduct(int idProduct)
        {
            var res = _imageService.GetImagesByIdProduct(idProduct);
            return Ok(res);
        }
    }
}
