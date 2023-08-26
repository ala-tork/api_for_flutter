using api_for_flutter.Models.CategoryModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_for_flutter.Models.FeaturesModel;

namespace api_for_flutter.Models.FeaturesCategoryModel
{
    public class FeatureCategory
    {
        [Key]
        public int IdFC { get; set; }

        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Categories Category { get; set; }

        public int IdFeature { get; set; }
        [ForeignKey("IdFeature")]
        public Features Feature { get; set; }
    }
}
