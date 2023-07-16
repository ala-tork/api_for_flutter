using api_for_flutter.Models.AdsModels;

namespace api_for_flutter.Services.AdsServices
{
    public interface Iservices
    {
        List<Ads> GetAds();
        List<Ads> ofset(int page);
        Task<Ads> CreateAdd(CreateAds ad);
        Ads GetAdById(int id);
        int NbrAds();
    }
}
