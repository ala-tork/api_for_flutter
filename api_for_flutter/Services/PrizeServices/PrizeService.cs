using System;
using System.Threading.Tasks;
using api_for_flutter.Models.PrizesModel;
using api_for_flutter.Models.PrizeModel;
using Microsoft.EntityFrameworkCore;
using api_for_flutter.Data;

namespace api_for_flutter.Services.PrizeServices
{
    public class PrizeService : IPrizeService
    {
        private readonly ApplicationDBContext _dbContext; 

        public PrizeService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Prizes> CreatePrize(CreatePrize createPrize)
        {
            var prize = new Prizes
            {
                Title = createPrize.Title,
                Image = createPrize.Image,
                Description = createPrize.Description,
                DatePrize = createPrize.DatePrize,
                IdUser = createPrize.IdUser,
                Active = createPrize.Active
            };

            _dbContext.Prizes.Add(prize);
            await _dbContext.SaveChangesAsync();

            return prize;
        }

        public async Task<Prizes> DeletePrize(int idPrize)
        {
            var prize = await _dbContext.Prizes.FindAsync(idPrize);

            if (prize == null)
            {
                return null; 
            }

            _dbContext.Prizes.Remove(prize);
            await _dbContext.SaveChangesAsync();

            return prize;
        }

        public async Task<Prizes> GetPrizeByDeals(int idDeals)
        {
            var prize = await _dbContext.Prizes.FirstOrDefaultAsync(p => p.IdUser == idDeals);

            return prize;
        }

        public async Task<Prizes> GetPrizeById(int id)
        {
            var res = await _dbContext.Prizes.FirstOrDefaultAsync(p=>p.IdPrize == id);
            if (res != null)
            {
                return res;
            }
            return null;
        }

        public async Task<Prizes> UpdatePrize(CreatePrize updatePrize,int id)
        {
            var prize = await _dbContext.Prizes.FindAsync(id);

            if (prize == null)
            {
                return null; 
            }

            prize.Title = updatePrize.Title;
            prize.Image = updatePrize.Image;
            prize.Description = updatePrize.Description;
            prize.DatePrize = updatePrize.DatePrize;
            prize.IdUser = updatePrize.IdUser;
            prize.Active = updatePrize.Active;

            await _dbContext.SaveChangesAsync();

            return prize;
        }
    }
}
