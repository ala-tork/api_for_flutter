using api_for_flutter.Data;
using api_for_flutter.Models.Features;
using api_for_flutter.Models.FeaturesModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace api_for_flutter.Services.FeatuesServices
{
    public class FeaturesService : IFeaturesService
    {
        protected readonly ApplicationDBContext _dbContext;
        public FeaturesService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Features> AddFeature(CreateFeature feature)
        {
            var f = new Features
            {
                Title = feature.Title,
                Description = feature.Description,
                Unit = feature.Unit,
                idCategory = feature.idCategory,
                Active = feature.Active,
            };

            _dbContext.Features.Add(f);
            await _dbContext.SaveChangesAsync();

            return f;
        }

        public async Task<List<Features>> GetAllFeatures()
        {
            var featuresList = await _dbContext.Features.Include(f => f.Categorie).ToListAsync();
            return featuresList;
        }

        public async Task<List<Features>> GetAllFeaturesByCategory(int idcategory)
        {
            var featuresList = await _dbContext.Features
                                              .Where(f => f.idCategory == idcategory)
                                              .ToListAsync();

            return featuresList;
        }
    }
}
