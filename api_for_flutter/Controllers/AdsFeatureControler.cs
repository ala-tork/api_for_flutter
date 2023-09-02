using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Services.AdsFeatureSerices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsFeatureControler : ControllerBase
    {
        protected readonly IAdsFeatureService _service;
        public AdsFeatureControler(IAdsFeatureService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeatureAds(CreateAdsFeature createAdsFeature)
        {
            if(createAdsFeature == null)
            {
                return BadRequest();
            }
            var x= await _service.AddAdsFeature(createAdsFeature);
            return Ok(x);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdsFeaturesByIdAds(int idAds)
        {
            
            var res = await _service.GetAllAdsFeatures(idAds);
            if(res!=null)
            {
                return Ok(res);
            }
            return BadRequest("ther is no Ads Features for this Ads ID");
            
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdsFeaturesByAdsId(int idAds)
        {
            var res = await _service.DeleteAdsFeatures(idAds);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("adsFeatures Not Found ");
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdsFeatures(CreateAdsFeature adsFeature,int idAF)
        {
            if(adsFeature!=null && idAF != null)
            {
                var res = _service.UpdateFeatures(adsFeature, idAF);
                return Ok(res);
            }
            return BadRequest("we cant update this feature Ads");
        }

        // Deals EndPoint

        [HttpGet("GetDealsFeatures")]
        public async Task<IActionResult> GetAllDealsFeaturesByIdDeals(int idDeals)
        {

            var res = await _service.GetAllDealsFeatures(idDeals);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("ther is no Deals Features for this Deals ID");

        }
        [HttpDelete("DeleteDealstFeatures")]
        public async Task<IActionResult> DeleteDealsFeaturesByDealsId(int idDeals)
        {
            var res = await _service.DeleteDealsFeatures(idDeals);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Deals Features Not Found ");

        }

        [HttpPut("UpdateDealsFeatures")]
        public async Task<IActionResult> UpdateDealsFeatures(CreateAdsFeature adsFeature, int idDeals)
        {
            if (adsFeature != null && idDeals != null)
            {
                var res = _service.UpdateDealsFeatures(adsFeature, idDeals);
                return Ok(res);
            }
            return BadRequest("we cant update this Deals feature");
        }


        // Product Endpoints

        [HttpGet("GetAllProductFeatures")]
        public async Task<IActionResult> GetAllProductFeatures(int idProduct)
        {
            var res = await _service.GetAllProductFeatures(idProduct);
            return Ok(res);
        }

        [HttpDelete("DeleteProductFeatures")]
        public async Task<IActionResult> DeleteProductFeatures(int idProduct)
        {
            var res = await _service.DeleteProductFeatures(idProduct);
            if (res.Count == 0)
            {
                return BadRequest("Product Features Not Found");
            }

            return Ok(res);
        }

        [HttpPut("UpdateProductFeatures")]
        public async Task<IActionResult> UpdateProductFeatures(CreateAdsFeature features, int idProduct)
        {
            var res = await _service.UpdateProductFeatures(features, idProduct);
            if (res == null)
            {
                return BadRequest("Unable to update Product Features");
            }

            return Ok(res);
        }
    }
}
