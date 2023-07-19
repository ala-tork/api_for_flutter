using api_for_flutter.Models.FeaturesModels;
using api_for_flutter.Services.FeatuesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesControler : ControllerBase
    {
        protected readonly IFeaturesService _featuresService;
        public FeaturesControler(IFeaturesService featuresService)
        {
              _featuresService= featuresService;
        }
        [HttpPost("AddFeature")]
        public async Task<IActionResult> AddFeature(CreateFeature createFeature)
        {
            if (createFeature == null)
            {
                return BadRequest();
            }
            await _featuresService.AddFeature(createFeature);
            return Ok(createFeature);
        }

        [HttpGet("GetAllFeatures")]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featuresService.GetAllFeatures();
            return Ok(features);
        }

        [HttpGet("GetFeatureByCategory")]
        public async Task<IActionResult> GetFeatures(int idcateg)
        {
            var features = await _featuresService.GetAllFeaturesByCategory(idcateg);
            return Ok(features);
        }
    }
}
