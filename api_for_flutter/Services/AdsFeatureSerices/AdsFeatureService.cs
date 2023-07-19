using api_for_flutter.Data;
using api_for_flutter.Models.AdsFeaturesModel;

namespace api_for_flutter.Services.AdsFeatureSerices
{
    public class AdsFeatureService:IAdsFeatureService
    {
        protected readonly ApplicationDBContext _dbContext;
        public AdsFeatureService (ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AdsFeatures> AddAdsFeature(CreateAdsFeature features)
        {
            var af = new AdsFeatures
            {
                IdAds = features.IdAds,
                IdDeals = features.IdDeals,
                IdFeature = features.IdFeature,
                IdFeaturesValues = features.IdFeaturesValues,
                MyValues = features.MyValues,
                Active = features.Active,

            }; 

            await _dbContext.AdsFeatures.AddAsync(af);
            await _dbContext.SaveChangesAsync();
            return af;
        }
    }
}
