using api_for_flutter.Data;
using api_for_flutter.Models;
using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.Features;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.Images_Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace api_for_flutter.Services.AdsServices
{
    public class Service : Iservices
    {
        private readonly ApplicationDBContext _context;
        private readonly IAdsFeatureService _featureService;
        private readonly IImageService _imageService;
        public Service(ApplicationDBContext context, IAdsFeatureService adsFeatureService)
        {
            _featureService = adsFeatureService;
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
                Active = ad.Active,
            };

            _context.Ads.Add(newAd);

            // Save changes to the database
            await _context.SaveChangesAsync();

            //var idads = newAd.IdAds;

            //foreach (var item in ad.listFeatures_FeatureValues)
            //{
            //    var adsfeature = new CreateAdsFeature 
            //    {
            //        IdAds = idads,
            //        IdDeals = null,
            //        IdFeature = item.FeatureId,
            //        IdFeaturesValues = item.FeatureValueId,
            //        MyValues = null,
            //        Active = 1,
            //    };
            //    await _featureService.AddAdsFeature(adsfeature);
            //    await _context.SaveChangesAsync();
            //}
            //await _context.SaveChangesAsync();

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
