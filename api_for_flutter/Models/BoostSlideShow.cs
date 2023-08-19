using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models
{
    public class BoostSlideShow
    {

        public int BoostedId { get; set; }
        public string ItemType { get; set; }
        public string? DatePublication { get; set; }
        public double Price { get; set; }
        public string Locations { get; set; }
        public string? DateEND { get; set; }
        public int? Discount { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Deals? deals { get; set; }
        public Ads? ads { get; set; }
    }
}
