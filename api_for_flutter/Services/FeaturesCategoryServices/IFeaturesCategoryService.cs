using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Models.FeaturesCategoryModel;

namespace api_for_flutter.Services.FeaturesCategoryServices
{
    public interface IFeaturesCategoryService
    {
        Task<FeatureCategory> CreateFeatureCategory(CreateFeatureCategory createFeatureCategory);
        Task<List<Features>> GetAllFeaturesByCategory (int idCategory);
    }
}
