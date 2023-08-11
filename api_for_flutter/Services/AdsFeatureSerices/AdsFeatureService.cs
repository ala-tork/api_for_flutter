using api_for_flutter.Data;
using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Models.AdsModels;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;

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

        public async Task<List<AdsFeatures>> DeleteAdsFeatures(int idAds)
        {
            var adsFeaturesToDelete = await _dbContext.AdsFeatures.Where(af => af.IdAds == idAds).ToListAsync();

            if (adsFeaturesToDelete.Count > 0)
            {
                _dbContext.AdsFeatures.RemoveRange(adsFeaturesToDelete);
                await _dbContext.SaveChangesAsync();
            }

            return adsFeaturesToDelete;
        }

        public async Task<List<AdsFeatures>> GetAllAdsFeatures(int idAds)
        {
            var res = await _dbContext.AdsFeatures.Where(af => af.IdAds == idAds)
                                                .Include(af=>af.features)
                                                .Include(af=>af.FeaturesValues).ToListAsync();
            return res;
        }

        public async Task<AdsFeatures> UpdateFeatures(CreateAdsFeature features,int idAF)
        {
            var existingFeatures = await _dbContext.AdsFeatures.FindAsync(idAF);

            if (existingFeatures != null)
            {
                
                existingFeatures.IdAds = features.IdAds;
                existingFeatures.IdDeals = features.IdDeals;
                existingFeatures.IdFeature = features.IdFeature;
                existingFeatures.IdFeaturesValues = features.IdFeaturesValues;
                existingFeatures.MyValues = features.MyValues;
                existingFeatures.Active = features.Active;

                await _dbContext.SaveChangesAsync();
            }

            return existingFeatures;
        }


        // Deals Fucntions 



        public async Task<List<AdsFeatures>> GetAllDealsFeatures(int idDeals)
        {
            var res = await _dbContext.AdsFeatures.Where(af => af.IdDeals == idDeals)
                                    .Include(af => af.features)
                                    .Include(af => af.FeaturesValues).ToListAsync();
            return res;
        }

        public async  Task<List<AdsFeatures>> DeleteDealsFeatures(int idDeals)
        {
            var dealsFeaturesToDelete = await _dbContext.AdsFeatures.Where(af => af.IdDeals == idDeals).ToListAsync();

            if (dealsFeaturesToDelete.Count > 0)
            {
                _dbContext.AdsFeatures.RemoveRange(dealsFeaturesToDelete);
                await _dbContext.SaveChangesAsync();
            }

            return dealsFeaturesToDelete;
        }

        public async  Task<AdsFeatures> UpdateDealsFeatures(CreateAdsFeature features, int idDeals)
        {
            var existingFeatures = await _dbContext.AdsFeatures.FindAsync(idDeals);

            if (existingFeatures != null)
            {

                //existingFeatures.IdAds = features.IdAds;
                existingFeatures.IdDeals = features.IdDeals;
                existingFeatures.IdFeature = features.IdFeature;
                existingFeatures.IdFeaturesValues = features.IdFeaturesValues;
                existingFeatures.MyValues = features.MyValues;
                existingFeatures.Active = features.Active;

                await _dbContext.SaveChangesAsync();
            }

            return existingFeatures;
        }
    }
}
