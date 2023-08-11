
namespace api_for_flutter.Models.LikesPublicationModel
{
    public class CreateLikeModel
    {

        public int IdUser { get; set; }
        public int? IdProd { get; set; }
        public int? IdAd { get; set; }

        public int? IdDeal { get; set; }

        public string? MyDate { get; set; }

    }
}
