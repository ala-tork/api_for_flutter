using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.BootsModel
{
    public class Boosts
    {
        [Key]
        public int IdBoost { get; set; }
        public string TitleBoost { get; set; }
        public double Price { get; set; }
        public string? Discount { get; set; }
        public int? MaxDurationPerDay { get; set; }
        public int? InSliders { get; set; }
        public int? InSideBar { get; set; }
        public int? InFooter { get; set; }
        public int? InRelatedPost { get; set; }
        public int? InFirstLogin { get; set; }
        public int? HasLinks { get; set; }
        public int? Orders { get; set; }

    }
}
