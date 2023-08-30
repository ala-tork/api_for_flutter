using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Models.AdsModels;

namespace api_for_flutter.Services.AdsServices
{
    public interface Iservices
    {
        List<Ads> GetAds();
        public List<Ads> ShowMore(int page = 0);
        public List<Ads> ShowMoreByIdUser(int iduser,int page = 0,int pagesize=4);
        Task<Ads> CreateAdd(CreateAds ad);
        Ads GetAdById(int id);
        int NbrAds();
        int NbrAdsByIdUser(int iduser);
        Task<Ads> DeleteAdsById(int id);
        Task<Ads> updateAds(CreateAds ads,int id);
       // Task<CreateAdsFeature> ShowME(CreateAds ad);
    }
}
