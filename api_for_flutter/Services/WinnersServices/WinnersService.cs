using api_for_flutter.Data;
using api_for_flutter.Models.PrizeModel;
using api_for_flutter.Models.UserModel;
using api_for_flutter.Models.WinnersModel;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task<List<Winners>> GetRandomWinners()
        {
            int numberOfRandomWinners = 2;

            var randomWinners = await _dbContext.Winners
                .FromSqlRaw($"SELECT TOP {numberOfRandomWinners} * FROM Winners ORDER BY CHECKSUM(NEWID())")
                .Include(winner => winner.prizes)
                .Include(winner => winner.user)
                .ToListAsync();

            return randomWinners;
        }






        public async  Task<List<Winners>> getWinners()
        {
            var res =  _dbContext.Winners.ToList();

            return res;
        }
    }
}
