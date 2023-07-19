﻿using api_for_flutter.Models.AdsModels;
using f = api_for_flutter.Models.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_for_flutter.Models.FeaturesValuesModel;

namespace api_for_flutter.Models.AdsFeaturesModel
{
    public class AdsFeatures
    {
        [Key]
        public int IdAF { get; set; }
        public int? IdAds { get; set; }
       /* [ForeignKey("IdAds")]
        public Ads? Ads { get; set; }*/
        public int? IdDeals { get; set; }
       /* [ForeignKey("IdDeals")]
        public Deals? Deals { get; set; }*/
        public int? IdFeature { get; set; }
       [ForeignKey("IdFeature")]
        public f.Features? features { get; set; }
        public int? IdFeaturesValues { get; set; }
        [ForeignKey("IdFeaturesValues")]
        public FeaturesValues? FeaturesValues { get; set; }
        public string? MyValues { get; set; }
        public int Active { get; set; }

    }
}