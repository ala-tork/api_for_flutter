using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
//using CoolApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.DealsModel
{
    public class CreateDeals
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int? Discount { get; set; }
        public int Quantity { get; set; }
        public int? IdPricesDelevery { get; set; }
        public string? DatePublication { get; set; }
        public string? DateEND { get; set; }
        public string? ImagePrinciple { get; set; }
        public string? VideoName { get; set; }
        public int IdCateg { get; set; }
        public int IdUser { get; set; }
        public int IdCountrys { get; set; }
        public int IdCity { get; set; }
        public int IdBrand { get; set; }
        public int? IdPrize { get; set; }
        public string Locations { get; set; }
        public int? IdBoost { get; set; }
        public int Active { get; set; }
    }
}
