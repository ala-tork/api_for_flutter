using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.WinnersModel
{
    public class CreateWinner
    {
        public int IdPrize { get; set; }
        public string DateWin { get; set; }
        public int IdUser { get; set; }
        public int PriceRecived { get; set; }
    }
}
