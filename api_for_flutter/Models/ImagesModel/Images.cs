using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Models.PrizeModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.ImagesModel
{
    public class Images
    {
        [Key]
        public int IdImage { get; set; }
        public string Title { get; set; }
        public string? Type { get; set; }
        public int? IdAds { get; set; }
        [ForeignKey("IdAds")]
        public Ads? Ads { get; set; }
        public int? IdDeals { get; set; }
        [ForeignKey("IdDeals")]
        public Deals? Deals { get; set; } 
        public int? IdProduct { get; set; }
        public int? IdPrize { get; set; }
        [ForeignKey("IdPrize")]
        public Prizes? Prizes { get; set; }
        public int Active { get; set; }
    }
}
