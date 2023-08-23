using api_for_flutter.Models.PrizeModel;
using api_for_flutter.Models.PrizesModel;

namespace api_for_flutter.Services.PrizeServices
{
    public interface IPrizeService
    {
        Task<Prizes> CreatePrize(CreatePrize createPrize);
        Task<Prizes> UpdatePrize(CreatePrize updatePrize,int id);
        Task<Prizes> DeletePrize(int idPrize);
        Task<Prizes> GetPrizeByDeals(int idDeals);
        Task<Prizes> GetPrizeById(int id);
    }
}
