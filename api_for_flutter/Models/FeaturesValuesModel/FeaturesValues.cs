using api_for_flutter.Models.AdsModels;
using FeatureModels = api_for_flutter.Models.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.FeaturesValuesModel
{
   /* public class FeaturesValues
    {
        [Key]
        public int IdFv { get; set; }
        public string title { get; set; }
        public int Active { get; set; }
        public int IdF { get; set; }

        [ForeignKey("IdF")]
        public FeatureModels.Features? features { get; set; }

        public List<int>? IdAds { get; set; }
        public List<Ads>? Ads { get; set; }
    }*/
       public class FeaturesValues
       {
           [Key]
           public int IdFv { get; set; }
           public string title { get; set; }
           public int Active { get; set; }
           public int IdF { get; set; }

           [ForeignKey("IdF")]
           public FeatureModels.Features features { get; set; }

        // public int IdAds { get; set; }

        //[ForeignKey("IdAds")]
        // public Ads? Ads { get; set; }
    }
}
