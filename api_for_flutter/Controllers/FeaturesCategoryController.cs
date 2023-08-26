using Microsoft.AspNetCore.Mvc;
using api_for_flutter.Models.FeaturesCategoryModel;
using api_for_flutter.Services.FeaturesCategoryServices;
using System.Threading.Tasks;
using api_for_flutter.Models.FeaturesModel;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesCategoryController : ControllerBase
    {
        private readonly IFeaturesCategoryService _featuresCategoryService;

        public FeaturesCategoryController(IFeaturesCategoryService featuresCategoryService)
        {
            _featuresCategoryService = featuresCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult<FeatureCategory>> CreateFeatureCategory(CreateFeatureCategory createFeatureCategory)
        {
            var newFeatureCategory = await _featuresCategoryService.CreateFeatureCategory(createFeatureCategory);
            return Ok(newFeatureCategory);
        }

        [HttpGet("category/{idCategory}")]
        public async Task<ActionResult<Features>> GetAllFeaturesByCategory(int idCategory)
        {
            var featuresInCategory = await _featuresCategoryService.GetAllFeaturesByCategory(idCategory);
            return Ok(featuresInCategory);
        }
    }
}
