using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.WishListModel
{
    public class CreateWishList
    {
        public int IdUser { get; set; }
        public int? IdDeal { get; set; }
        public int? IdProd { get; set; }
        public int? IdAd { get; set; }
        public string? MyDate { get; set; }
    }
}
