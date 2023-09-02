using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.UserModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public string? ImageUrl { get; set; }
        public string? phone { get; set; } = "";
        public string? country { get; set; } = "";
        public string? address { get; set; } = "";
        public string role { get; set; } = "User";
        public string DateInscription { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public int active { get; set; } = 0;
        public int isPro { get; set; } = 0;
        public int isverified { get; set; } = 0;
        public int isPremium { get; set; } = 0;
        public int NbDiamon { get; set; } = 0;
        public string RefreshToken { get; set; } = "";


    }
}