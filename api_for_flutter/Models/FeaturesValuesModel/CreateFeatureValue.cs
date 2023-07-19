using api_for_flutter.Models.AdsModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FeatureModels = api_for_flutter.Models.Features;

namespace api_for_flutter.Models.FeaturesValuesModel
{
    public class CreateFeatureValue
    {

        public string title { get; set; }
        public int Active { get; set; }
        public int IdF { get; set; }
       // public int? IdAds { get; set; }

    }
}
