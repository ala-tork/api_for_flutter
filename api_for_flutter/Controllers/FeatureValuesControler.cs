using api_for_flutter.Models.FeaturesValuesModel;
using api_for_flutter.Services.FeatureValueServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureValuesControler : ControllerBase
    {
        protected readonly IFeatureValueService _FeatureValueService;
        public FeatureValuesControler(IFeatureValueService featureValueService)
        {
            _FeatureValueService = featureValueService;
        }

        [HttpPost("AddFeatureValue")]
        public async Task<IActionResult> AddFeatureValue(CreateFeatureValue createFeatureValue)
        {
            var fv = await _FeatureValueService.AddFeatureValue(createFeatureValue);
            return Ok(fv);
        }

        [HttpGet("GetAllFeatureValues")]
        public async Task<IActionResult> GetAllFeatureValues()
        {
            var fv = await _FeatureValueService.GetAllFeaturesValues();
            return Ok(fv);
        }

        [HttpGet("GetFeatureValuesByFeature")]
        public async Task<IActionResult> GetFeatureValueByFeature(int idf)
        {
            var f = await _FeatureValueService.GetFeaturesValuesByFeature(idf);
           if(f == null)
            {
                return NotFound();
            }
           return Ok(f);
        }

       /* [HttpGet("GetFeaturevaluesByAds")]
        public async Task<IActionResult> GetFeaturValuesByAds(int idAds)
        {
            var fv = await _FeatureValueService.GetFeaturesValuesByAds(idAds);
            if(fv == null)
            {
                return NotFound();
            }
            return Ok(fv);
        }*/
    }
}
