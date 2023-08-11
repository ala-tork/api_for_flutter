namespace api_for_flutter.Models
{
    public class AdsFilter
    {
        public string? adsName { get; set; }
        public int? IdCountrys { get; set; }
        public int? IdCity { get; set; }
        public List<int?> IdFeaturesValues { get; set; }
        public int? IdCategory { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public int PageNumber { get; set; }
    }

}
