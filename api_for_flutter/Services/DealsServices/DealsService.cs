using api_for_flutter.Data;
using api_for_flutter.Models.DealsModel;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.DealsServices
{
    public class DealsService : IDealsService
    {
        private readonly ApplicationDBContext _context;
        public DealsService(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<Deals> CreateDeal(CreateDeals dl)
        {
            var deal = new Deals
            {
                Title = dl.Title,
                Description = dl.Description,
                Details = dl.Details,
                Price = dl.Price,
                Discount = dl.Discount,
                Quantity = dl.Quantity,
                IdPricesDelevery = dl.IdPricesDelevery,
                DatePublication = DateTime.Now.ToString("yyyy-MM-dd"),
                DateEND = dl.DateEND,
                ImagePrinciple = dl.ImagePrinciple,
                VideoName = dl.VideoName,
                IdCateg = dl.IdCateg,
                IdUser = dl.IdUser,
                IdCountrys = dl.IdCountrys,
                IdCity = dl.IdCity,
                IdBrand = dl.IdBrand,
                IdPrize = dl.IdPrize,
                Locations = dl.Locations,
                IdBoost = dl.IdBoost,
                Active = dl.Active,
                
            };

            _context.Deals.Add(deal);
            await _context.SaveChangesAsync();
            return deal;
        }

        public async Task<Deals> DeleteDealsById(int id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if (deal != null)
            {
                _context.Deals.Remove(deal);
                await _context.SaveChangesAsync();
            }
            return deal;
        }

        public List<Deals> GetDeals()
        {
            return _context.Deals.Where(d=>d.Active==1).ToList();
        }

        public Deals GetDealsById(int id)
        {
            return _context.Deals
                .Where(d => d.IdDeal == id && d.Active == 1)
                .Include(d => d.user)
                .Include(d => d.Categories)
                .Include(d => d.Countries)
                .Include(d => d.Cities)
                .FirstOrDefault();
        }


        public int NbrAds()
        {
            return _context.Deals.Count();
        }

        public int NbrDealsByIdUser(int iduser)
        {
            return _context.Deals.Count(d => d.IdUser == iduser && d.Active == 1);
        }

        public List<Deals> ShowMore(int page = 0)
        {
            const int pageSize = 4; 
            var skip = page * pageSize;
            return _context.Deals.Where(d=>d.Active == 1).Skip(skip).Take(pageSize).ToList();
        }

        public List<Deals> ShowMoreByIdUser(int iduser, int page = 0)
        {
            const int pageSize = 4; 
            var skip = page * pageSize;
            return _context.Deals.Where(d => d.IdUser == iduser && d.Active == 1).Skip(skip).Take(pageSize).ToList();
        }

        public async Task<Deals> UpdateDeals(CreateDeals deal, int id)
        {
            var existingDeal = await _context.Deals.FindAsync(id);
            if (existingDeal != null)
            {
                existingDeal.Title = deal.Title;
                existingDeal.Description = deal.Description;
                existingDeal.Details = deal.Details;
                existingDeal.Price = deal.Price;
                existingDeal.Discount = deal.Discount;
                existingDeal.Quantity = deal.Quantity;
                existingDeal.IdPricesDelevery = deal.IdPricesDelevery;
                existingDeal.DatePublication = deal.DatePublication;
                existingDeal.DateEND = deal.DateEND;
                existingDeal.ImagePrinciple = deal.ImagePrinciple;
                existingDeal.VideoName = deal.VideoName;
                existingDeal.IdCateg = deal.IdCateg;
                existingDeal.IdUser = deal.IdUser;
                existingDeal.IdCountrys = deal.IdCountrys;
                existingDeal.IdCity = deal.IdCity;
                existingDeal.IdBrand = deal.IdBrand;
                existingDeal.IdPrize = deal.IdPrize;
                existingDeal.Locations = deal.Locations;
                existingDeal.IdBoost = deal.IdBoost;
                existingDeal.Active = deal.Active;

                await _context.SaveChangesAsync();
            }
            return existingDeal;
        }
    }
}
