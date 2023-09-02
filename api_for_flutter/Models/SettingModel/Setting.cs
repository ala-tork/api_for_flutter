using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.SettingModel
{
    public class Setting
    {
        [Key]
        public int IdSetting { get; set; }
        public string? PrivacyPolicy { get; set; }
        public string? PolicyRetour { get; set; }
        public string? TermsAndConditions { get; set; }
        public double? PROUserMonthPrice { get; set; }
        public double? PROEntrepriseMonthPrice { get; set; }
        public double? TransfertCommision { get; set; }
        public int? MinimumSubscriptionDuration { get; set; }
        public int? StandardAnnonceMaxDuration { get; set; }
        public int? StandardDealsMaxDuration { get; set; }
        public int? StandardMaxMagasin { get; set; }
        public int? StandardAccountMaxAnnonces { get; set; }
        public int? StandardAccountMaxDeals { get; set; }
        public int? StandardAccountMaxProduts { get; set; }
        public bool? ModeMagasinAndDeals { get; set; }
        public double? StandardAchatCommision { get; set; }
        public int? StandardAccountMaxPoints { get; set; }
        public int? MinimumAddAnnoncePoints { get; set; }
        public int? MinimumAddDealsPoints { get; set; }
        public int? MinimumAddProductsPoints { get; set; }
        public bool? CreationRatingPreviewForStandardAccount { get; set; }
        public bool? BoostAds { get; set; }
        public bool? UpgradeAccount { get; set; }
        public bool? BuyPoints { get; set; }
        public bool? PremiumAccount { get; set; }
        public bool? RatingPreview { get; set; }
        public int NbDiamondAds { get; set; }
        public int NbDiamondDeals { get; set; }
        public int NbDiamondProduct { get; set; }
    }

}
