using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.LikesPublicationModel
{
    public class Like
    {
        [Key]
        public int IdLP { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; } 
        public int? IdProd { get; set; }
        public int? IdAd { get; set; }
        [ForeignKey("IdAd")]
        public Ads? Ads { get; set; }
        public int? IdDeal { get; set; }
        [ForeignKey("IdDeal")]
        public Deals? Deals { get; set; }
        public string? MyDate { get; set; }


    }
}
