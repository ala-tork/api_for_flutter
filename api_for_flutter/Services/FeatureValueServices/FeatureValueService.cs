﻿using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.FeaturesValuesModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace api_for_flutter.Services.FeatureValueServices
{
    public class FeatureValueService : IFeatureValueService
    {
        protected readonly ApplicationDBContext _dbContext;


        public FeatureValueService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FeaturesValues> AddFeatureValue(CreateFeatureValue cfv)
        {
            var featuresValue = new FeaturesValues
            {
                title = cfv.title,
                Active = cfv.Active,
                IdF = cfv.IdF
            };
            
            _dbContext.FeaturesValues.Add(featuresValue);
            _dbContext.SaveChanges();
            return featuresValue;
        }

        public async  Task<List<FeaturesValues>> GetAllFeaturesValues()
        {
            var featuresValues = await _dbContext.FeaturesValues.Where(fv=>fv.Active==1).ToListAsync();
            return featuresValues;
        }

       /* public async Task<List<FeaturesValues>> GetFeaturesValuesByAds(int idAds)
        {
            var featureList = await _dbContext.FeaturesValues.Where(f=> f.IdAds == idAds).ToListAsync();
            return featureList;
        */

        public async Task<List<FeaturesValues>> GetFeaturesValuesByFeature( int idf)
        {
            var featuresValues = await _dbContext.FeaturesValues
                        .Where(f => f.IdF == idf && f.Active==1).Include(f=>f.features).ToListAsync();
            return featuresValues;
        }

        public async Task<FeaturesValues> GetFeatureValueById(int id)
        {
            var featurevalue = await _dbContext.FeaturesValues.FirstOrDefaultAsync(f => f.IdF == id && f.Active==1);
            return featurevalue;
        }




        /* public  Task<FeaturesValues> AddIdAdsToFeatureValue(int featureValueId, int idAds)
         {

             var featureValue =  _dbContext.FeaturesValues.Find(featureValueId);

             if (featureValue == null)
             {

                 throw new ArgumentException("FeatureValue not found.");
             }


             if (featureValue.IdAds == null)
             {
                 featureValue.IdAds = new List<int>();
             }

             featureValue.IdAds.Add(idAds);

              _dbContext.SaveChanges();

             return featureValue;
         }*/
    }
}
