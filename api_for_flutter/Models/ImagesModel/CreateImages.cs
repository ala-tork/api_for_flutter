using api_for_flutter.Models.AdsModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.ImagesModel
{
    public class CreateImages
    {
        public string Title { get; set; }
        public string? Type { get; set; }
        public int? IdAds { get; set; }
        public int? IdDeals { get; set; }
        public int? IdPrize { get; set; }
        public int? IdProduct { get; set; }
        public int Active { get; set; }
    }
}
