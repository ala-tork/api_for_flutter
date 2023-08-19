using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.AdsModels
{
    public class CreateAds
    {
        //public int IdAds { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string details { get; set; }
        public double Price { get; set; }
        public int IdUser { get; set; }
        public string? ImagePrinciple { get; set; }
        public string? VideoName { get; set; }
        public int IdCateg { get; set; }
        public int IdCountrys { get; set; }
        public int IdCity { get; set; }
        public string Locations { get; set; }
        public int? IdBoost { get; set; }
        public int Active { get; set; }

    }

}
