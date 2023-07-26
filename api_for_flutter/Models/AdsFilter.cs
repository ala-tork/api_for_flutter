namespace api_for_flutter.Models
{
    public class AdsFilter
    {
        public int? IdCountrys { get; set; }
        public int? IdCity { get; set; }
        public List<int?> IdFeaturesValues { get; set; }
        public int? IdCategory { get; set; }
        public int PageNumber { get; set; } 
    }

}
