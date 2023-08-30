using api_for_flutter.Models.WinnersModel;

namespace api_for_flutter.Services.WinnersServices
{
    public interface IWinnerService
    {
        public Task<List<Winners>> getWinners();
        public Task<Winners> CreateWinner(CreateWinner winners);
        public Task<List<Winners>> GetRandomWinners();
    }
}
