using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Models.ProductModel;
using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.WishListModel
{
    public class WishList
    {
        [Key]
        public int Idwish { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; }
        public int? IdDeal { get; set; }
        [ForeignKey("IdDeal")]
        public Deals? deals { get; set; }
        public int? IdProd { get; set; }
        [ForeignKey("IdProd")]
        public Product? Product { get; set; }
        public int? IdAd { get; set; }
        [ForeignKey("IdAd")]
        public Ads? ads { get; set; }
        public string? MyDate { get; set; }
    }
}
