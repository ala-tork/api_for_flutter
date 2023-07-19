using api_for_flutter.Models.FeaturesValuesModel;

namespace api_for_flutter.Services.FeatureValueServices
{
    public interface IFeatureValueService
    {
        Task<FeaturesValues> AddFeatureValue(CreateFeatureValue cfv);
        Task<FeaturesValues> GetFeatureValueById(int id);
        Task<List<FeaturesValues>> GetAllFeaturesValues();
        Task<List<FeaturesValues>> GetFeaturesValuesByFeature(int idf);
        //Task<List<FeaturesValues>> GetFeaturesValuesByAds(int idAds);
    }
}
