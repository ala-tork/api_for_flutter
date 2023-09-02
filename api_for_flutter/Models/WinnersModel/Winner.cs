using api_for_flutter.Models.PrizeModel;
using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.WinnersModel
{
    public class Winners
    {
        [Key]
        public int IdWinner { get; set; }
        public int IdPrize { get; set; }
        [ForeignKey("IdPrize")]
        public Prizes prizes { get; set; }
        public string DateWin { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; }
        public int PriceRecived { get; set; }
    }
}
