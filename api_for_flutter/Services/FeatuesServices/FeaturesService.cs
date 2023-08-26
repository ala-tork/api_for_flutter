using api_for_flutter.Data;
using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Models.FeaturesModels;
using api_for_flutter.Services.FeatureValueServices;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.FeatuesServices
{
    public class FeaturesService : IFeaturesService
    {
        protected readonly ApplicationDBContext _dbContext;
        protected readonly IFeatureValueService _featuresValueService;
        public FeaturesService(ApplicationDBContext dbContext,IFeatureValueService featureValue)
        {
            _featuresValueService = featureValue;
            _dbContext = dbContext;
        }

        public async Task<Features> AddFeature(CreateFeature feature)
        {
            var f = new Features
            {
                Title = feature.Title,
                Description = feature.Description,
                Unit = feature.Unit,
               // idCategory = feature.idCategory,
                Active = feature.Active,
            };

            _dbContext.Features.Add(f);
            await _dbContext.SaveChangesAsync();

            return f;
        }

        public async Task<List<Features>> GetAllFeatures()
        {
            var featuresList = await _dbContext.Features
                .Where(f=>f.Active==1)
                //.Include(f => f.Categorie)
                .ToListAsync();
            return featuresList;
        }

        public async Task<List<Features>> GetAllFeaturesByCategory(int idcategory)
        {
            var featuresList = await _dbContext.Features
                                              .Where(
                f => /*f.idCategory == idcategory &&*/ f.Active==1)
                                              .ToListAsync();

            return featuresList;
        }


    }
}
