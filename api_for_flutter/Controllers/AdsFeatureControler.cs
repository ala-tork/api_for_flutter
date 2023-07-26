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
    }
}
