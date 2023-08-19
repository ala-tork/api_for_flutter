using api_for_flutter.Models.BootsModel;

namespace api_for_flutter.Services.BoostServices
{
    public interface IBoostService
    {
        public Task<Boosts> CreateBoost (CreateBoost createBoost);
        public Task<Boosts> UpdateBoost (CreateBoost updateBoost,int idBoost);
        public Task<Boosts> DeleteBoost(int idBoost);
        public Task<List<Boosts>> GetAllBoosts();

        public Task<Boosts> GetBoostById(int id);

    }
}
