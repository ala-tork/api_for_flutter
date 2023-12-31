﻿namespace api_for_flutter.Models.UserModel
{
    public class CreateUser
    {
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public string? ImageUrl { get; set; }
        public string? phone { get; set; } = "";
        public string? country { get; set; } = "";
        public string? address { get; set; } = "";
        public string role { get; set; } = "User";
        public DateTime DateInscription { get; set; } = DateTime.Today;
        public int active { get; set; } = 0;
        public string RefreshToken { get; set; } = "";
    }
}
