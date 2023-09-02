using api_for_flutter.Models.AdsFeaturesModel;

namespace api_for_flutter.Services.AdsFeatureSerices
{
    public interface IAdsFeatureService
    {
        //Ads functions
        Task<AdsFeatures> AddAdsFeature(CreateAdsFeature features);
        Task<List<AdsFeatures>> GetAllAdsFeatures(int idAds);
        Task<List<AdsFeatures>> DeleteAdsFeatures(int idAf);
        Task<AdsFeatures> UpdateFeatures(CreateAdsFeature features,int idAF);

        //Deals Functions 
        Task<List<AdsFeatures>> GetAllDealsFeatures(int idDeals);
        Task<List<AdsFeatures>> DeleteDealsFeatures(int idDeals);
        Task<AdsFeatures> UpdateDealsFeatures(CreateAdsFeature features, int idDeals);

        //Product Functions 
        Task<List<AdsFeatures>> GetAllProductFeatures(int idProduct);
        Task<List<AdsFeatures>> DeleteProductFeatures(int idProduct);
        Task<AdsFeatures> UpdateProductFeatures(CreateAdsFeature features, int idProduct);

    }
}
