using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Services.AdsServices
{
    public class Service : Iservices
    {
        private readonly ApplicationDBContext _context;
        public Service(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Ads> CreateAdd(CreateAds ad)
        {
            var newAd = new Ads
            {
                Title = ad.Title,
                Description = ad.Description,
                details = ad.details,
                Price = ad.Price,
                ImagePrinciple = ad.ImagePrinciple,
                VideoName = ad.VideoName,
                IdCateg = ad.IdCateg,
                IdCountrys = ad.IdCountrys,
                IdCity = ad.IdCity,
                Locations = ad.Locations,
                Active = ad.Active,
            };

            _context.Ads.Add(newAd);
            await _context.SaveChangesAsync();

            return newAd;
        }


        public List<Ads> GetAds()
        {

            var ads = _context.Ads.Include(a => a.Categories)
                .Include(a => a.Countries)
                .Include(a => a.Cities).ToList();

            return ads;
        }
        public int NbrAds()
        {
            var ads = GetAds();
            var n = ads.Count();
            return n;
        }

        public List<Ads> ofset(int page = 0)
        {
            int pageSize = 4;

            var query = _context.Ads.AsQueryable();

            int nbAds = query.Count();
            int nbPages = (int)Math.Ceiling((double)nbAds / pageSize);

            var ads = query.Skip(page * pageSize)
                           .Take(pageSize)
                           .Include(a => a.Categories)
                            .Include(a => a.Countries)
                            .Include(a => a.Cities)
                           .ToList();
            return ads;
        }

        public Ads GetAdById(int id)
        {
            return _context.Ads
                .Include(a => a.Categories)
                .Include(a => a.Countries)
                .Include(a => a.Cities)
                .FirstOrDefault(a => a.IdAds == id);
        }
    }
}
