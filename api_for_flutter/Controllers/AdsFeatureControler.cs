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
    }
}
