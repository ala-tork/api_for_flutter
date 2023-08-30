using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;

namespace api_for_flutter.Services.DealsServices
{
    public interface IDealsService
    {
        List<Deals> GetDeals();
        public List<Deals> ShowMore(int page = 0);
        public List<Deals> ShowMoreByIdUser(int iduser, int page = 0, int pageSize=4);
        Task<Deals> CreateDeal(CreateDeals dl);
        Deals GetDealsById(int id);
        int NbrAds();
        int NbrDealsByIdUser(int iduser);
        Task<Deals> DeleteDealsById(int id);
        Task<Deals> UpdateDeals(CreateDeals Deal, int id);
    }
}
