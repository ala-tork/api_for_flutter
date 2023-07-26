﻿using api_for_flutter.Models.AdsFeaturesModel;

namespace api_for_flutter.Services.AdsFeatureSerices
{
    public interface IAdsFeatureService
    {
        Task<AdsFeatures> AddAdsFeature(CreateAdsFeature features);
        Task<List<AdsFeatures>> GetAllAdsFeatures(int idAds);
        Task<List<AdsFeatures>> DeleteAdsFeatures(int idAf);

        Task<AdsFeatures> UpdateFeatures(CreateAdsFeature features,int idAF);
        
    }
}
