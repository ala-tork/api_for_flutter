﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_for_flutter.Models.BootsModel;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
using api_for_flutter.Models.FeaturesValuesModel;
using api_for_flutter.Models.UserModel;

namespace api_for_flutter.Models.AdsModels
{
    public class Ads
    {
        [Key]
        public int IdAds { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string details { get; set; }
        public double Price { get; set; }
        public int IdPricesDelevery { get; set; }
        public string DatePublication { get; set; }
        public string? ImagePrinciple { get; set; }
        public string? VideoName { get; set; }
        public int IdCateg { get; set; }
        [ForeignKey("IdCateg")]
        public Categories Categories { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; }
        public int IdCountrys { get; set; }
        [ForeignKey("IdCountrys")]
        public Countries Countries { get; set; }
        public int IdCity { get; set; }
        [ForeignKey("IdCity")]
        public Cities Cities { get; set; }
        public int? IdBoost { get; set; }
        [ForeignKey("IdBoost")]
        public Boosts? Boosts { get; set; }
        public string Locations { get; set; }
        public int Active { get; set; }
    }
}
