using api_for_flutter.Data;
using api_for_flutter.Models.WinnersModel;

namespace api_for_flutter.Services.WinnersServices
{
    public class WinnersService : IWinnerService
    {
        private readonly ApplicationDBContext _dbContext;

        public WinnersService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<Winners> CreateWinner(CreateWinner winners)
        {
            var winner = new Winners
            {
                IdPrize = winners.IdPrize,
                IdUser = winners.IdUser,
                DateWin = winners.DateWin,
                PriceRecived = winners.PriceRecived
            };
             await _dbContext.Winners.AddAsync(winner);
            await _dbContext.SaveChangesAsync();
            return winner;
        }

        public async  Task<List<Winners>> getWinners()
        {
            var res =  _dbContext.Winners.ToList();

            return res;
        }
    }
}
