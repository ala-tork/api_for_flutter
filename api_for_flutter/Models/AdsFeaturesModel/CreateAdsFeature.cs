using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Models.FeaturesValuesModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.AdsFeaturesModel
{
    public class CreateAdsFeature
    {
        public int? IdAds { get; set; }
        public int? IdDeals { get; set; }
        public int? IdProduct { get; set; }
        public int? IdFeature { get; set; }
        public int? IdFeaturesValues { get; set; }
        public string? MyValues { get; set; }
        public int Active { get; set; }
    }
}
