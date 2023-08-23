using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.PrizesModel
{
    public class CreatePrize
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string? DatePrize { get; set; }
        public int? IdUser { get; set; }
        public int Active { get; set; }
    }
}
