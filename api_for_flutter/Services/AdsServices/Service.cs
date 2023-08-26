using api_for_flutter.Data;
using api_for_flutter.Models;
using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.Images_Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                IdUser = ad.IdUser,
                ImagePrinciple = ad.ImagePrinciple,
                VideoName = ad.VideoName,
                IdCateg = ad.IdCateg,
                IdCountrys = ad.IdCountrys,
                IdCity = ad.IdCity,
                Locations = ad.Locations,
                IdBoost = ad.IdBoost,
                DatePublication = DateTime.Now.ToString("yyyy-MM-dd"),
                Active = ad.Active,
                
            };

            _context.Ads.Add(newAd);
            await _context.SaveChangesAsync();

            return newAd;
        }




        public List<Ads> GetAds()
        {

            var ads = _context.Ads.Where(a=>a.Active==1).Include(a => a.Categories)
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

        public List<Ads> ShowMore(int page = 0)
        {
            int pageSize = 4;

            var query = _context.Ads.AsQueryable();

                var ads = query.OrderBy(a => a.IdAds) 
                               .Skip(page * pageSize)
                               .Take(pageSize)
                               .Include(a=>a.user)
                               .Include(a => a.Categories)
                               .Include(a => a.Countries)
                               .Include(a => a.Cities)
                               .ToList();
                return ads;
            
        }

        public Ads GetAdById(int id)
        {
            return _context.Ads.Where(a => a.Active == 1)
                .Include(a => a.user)
                .Include(a => a.Categories)
                .Include(a => a.Countries)
                .Include(a => a.Cities)
                .FirstOrDefault(a => a.IdAds == id);
        }

        public async Task<Ads> DeleteAdsById(int id)
        {
            var res = await _context.Ads.SingleOrDefaultAsync(a => a.IdAds == id);

            if (res != null)
            {
                _context.Ads.Remove(res);
                await _context.SaveChangesAsync();
            }

            return res;
        }

        public List<Ads> ShowMoreByIdUser(int iduser,int page)
        {
            int pageSize = 4;

            var query = _context.Ads.AsQueryable();

            var ads = query.Where(a => a.IdUser == iduser)
                .Where(a=>a.Active == 1)
               .OrderBy(a => a.IdAds)
               .Skip(page * pageSize)
               .Take(pageSize)
               .Include(a => a.user)
               .Include(a => a.Categories)
               .Include(a => a.Countries)
               .Include(a => a.Cities)
               .ToList();
            return ads;
        }

        public int NbrAdsByIdUser( int iduser)
        {
            var res = _context.Ads.Where(a => a.IdUser == iduser).Where(a=>a.Active==1).Count();
            return res;
        }

        public async Task<Ads> updateAds(CreateAds ads, int id)
        {
            var ad = GetAdById(id);
            if (ad != null)
            {
                ad.Title = ads.Title;
                ad.Description = ads.Description;
                ad.details = ads.details;
                ad.IdCity = ads.IdCity;
                ad.IdCateg = ads.IdCateg;
                ad.IdCountrys = ads.IdCountrys;
                ad.IdUser = ads.IdUser;
                ad.IdBoost= ads.IdBoost;
                ad.ImagePrinciple = ads.ImagePrinciple;
                ad.Locations = ads.Locations;
                ad.Price = ads.Price;
                ad.VideoName = ads.VideoName;
                ad.Active=ads.Active;
                ad.DatePublication = DateTime.Now.ToString("yyyy-MM-dd");
                _context.Entry(ad).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return ad;
            }
            else
                return null;
        }


        // test to find the error 
        //public async Task<CreateAdsFeature> ShowME(CreateAds ad)
        //{
        //    var newAd = new Ads
        //    {
        //        Title = ad.Title,
        //        Description = ad.Description,
        //        details = ad.details,
        //        Price = ad.Price,
        //        IdUser = ad.IdUser,
        //        ImagePrinciple = ad.ImagePrinciple,
        //        VideoName = ad.VideoName,
        //        IdCateg = ad.IdCateg,
        //        IdCountrys = ad.IdCountrys,
        //        IdCity = ad.IdCity,
        //        Locations = ad.Locations,
        //        IdBoost = ad.IdBoost,
        //        Active = ad.Active,
        //    };

        //    _context.Ads.Add(newAd);

        //    // Save changes to the database
        //    await _context.SaveChangesAsync();

        //    var idads = newAd.IdAds;

        //    //Console.WriteLine("ads id is: " + idads);

        //    var adsfeature = new CreateAdsFeature();
        //    foreach (var item in ad.listFeatures_FeatureValues)
        //    {
        //        adsfeature = new CreateAdsFeature
        //        {
        //            IdAds = idads,
        //            IdDeals = null,
        //            IdFeature = item.FeatureId,
        //            IdFeaturesValues = item.FeatureValueId,
        //            MyValues = null,
        //            Active = 1,
        //        };
        //        await _featureService.AddAdsFeature(adsfeature);
        //    }

        //    return adsfeature;
        //}
    }
}
