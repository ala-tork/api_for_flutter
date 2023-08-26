using api_for_flutter.Models.CategoryModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.FeaturesCategoryModel
{
    public class CreateFeatureCategory
    {
        public int IdCategory { get; set; }
        public int IdFeature { get; set; }
    }
}
