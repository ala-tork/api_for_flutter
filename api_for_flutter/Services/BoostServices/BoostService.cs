using api_for_flutter.Data;
using api_for_flutter.Models.BootsModel;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.BoostServices
{
    public class BoostService : IBoostService
    {
        private readonly ApplicationDBContext _dbContext;

        public BoostService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Boosts> CreateBoost(CreateBoost createBoost)
        {
            var boost = new Boosts
            {
                TitleBoost = createBoost.TitleBoost,
                Price = createBoost.Price,
                Discount = createBoost.Discount,
                MaxDurationPerDay = createBoost.MaxDurationPerDay , 
                InSliders = createBoost.InSliders, 
                InSideBar = createBoost.InSideBar ,
                InFooter = createBoost.InFooter ,
                InRelatedPost = createBoost.InRelatedPost,
                InFirstLogin = createBoost.InFirstLogin,
                HasLinks = createBoost.HasLinks, 
                Orders = createBoost.Orders
            };

            _dbContext.Boosts.Add(boost);
            await _dbContext.SaveChangesAsync();

            return boost;
        }


        public async Task<Boosts> DeleteBoost(int idBoost)
        {
            var boost = await _dbContext.Boosts.FindAsync(idBoost);
            if (boost == null)
                return null;

            _dbContext.Boosts.Remove(boost);
            await _dbContext.SaveChangesAsync();

            return boost;
        }

        public async Task<List<Boosts>> GetAllBoosts()
        {
            return await _dbContext.Boosts.ToListAsync();
        }

        public async Task<Boosts> GetBoostById(int id)
        {
            return await _dbContext.Boosts.FindAsync(id);
        }

        public async Task<Boosts> UpdateBoost(CreateBoost updateBoost, int idBoost)
        {
            var existingBoost = await _dbContext.Boosts.FirstOrDefaultAsync(b => b.IdBoost == idBoost);
            if (existingBoost == null)
            {
                return null;
            }

            existingBoost.TitleBoost = updateBoost.TitleBoost;
            existingBoost.Price = updateBoost.Price;
            existingBoost.Discount = updateBoost.Discount;
            existingBoost.MaxDurationPerDay = updateBoost.MaxDurationPerDay;
            existingBoost.InSliders = updateBoost.InSliders;
            existingBoost.InSideBar = updateBoost.InSideBar;
            existingBoost.InFooter = updateBoost.InFooter;
            existingBoost.InRelatedPost = updateBoost.InRelatedPost;
            existingBoost.InFirstLogin = updateBoost.InFirstLogin;
            existingBoost.HasLinks = updateBoost.HasLinks;
            existingBoost.Orders = updateBoost.Orders;

            await _dbContext.SaveChangesAsync();
            return existingBoost;
        }
    }
}
