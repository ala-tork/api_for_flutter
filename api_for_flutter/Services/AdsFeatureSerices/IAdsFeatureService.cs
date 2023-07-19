using api_for_flutter.Models.AdsFeaturesModel;

namespace api_for_flutter.Services.AdsFeatureSerices
{
    public interface IAdsFeatureService
    {
        Task<AdsFeatures> AddAdsFeature(CreateAdsFeature features);

    }
}
