﻿using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Models.FeaturesModels;

namespace api_for_flutter.Services.FeatuesServices
{
    public interface IFeaturesService
    {
        Task<Features> AddFeature(CreateFeature feature);
        Task<List<Features>> GetAllFeatures();
        Task<List<Features>> GetAllFeaturesByCategory(int idcategory);
        //Task<List<FeaturesWithListValues>> GetAllFeaturesWithValues();
    }
}
