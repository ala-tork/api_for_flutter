using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Models.FeaturesCategoryModel;
using api_for_flutter.Services.FeaturesCategoryServices;
using api_for_flutter.Data;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services
{
    public class FeaturesCategoryService : IFeaturesCategoryService
    {
        private readonly ApplicationDBContext _dbContext; 

        public FeaturesCategoryService(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<FeatureCategory> CreateFeatureCategory(CreateFeatureCategory createFeatureCategory)
        {
            var featureCategory = new FeatureCategory
            {
                IdCategory = createFeatureCategory.IdCategory,
                IdFeature = createFeatureCategory.IdFeature
            };

            _dbContext.FeatureCategories.Add(featureCategory);
            await _dbContext.SaveChangesAsync();

            return featureCategory;
        }

        public async Task<List<Features>> GetAllFeaturesByCategory(int idCategory)
        {
            var featuresInCategory = new List<Features>();

            var featureCategories = await _dbContext.FeatureCategories
                .Where(fc => fc.IdCategory == idCategory)
                .ToListAsync();

            foreach (var featureCategory in featureCategories)
            {
                var feature = await _dbContext.Features.FindAsync(featureCategory.IdFeature);
                if (feature != null)
                {
                    featuresInCategory.Add(feature);
                }
            }

            return featuresInCategory;
        }
    }
}
