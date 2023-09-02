using api_for_flutter.Models.BootsModel;
using api_for_flutter.Models.BrandsModel;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
using api_for_flutter.Models.PrizeModel;
using api_for_flutter.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Models.ProductModel
{
    public class Product
    {
        [Key]
        public int IdProd { get; set; }
        public string CodeBar { get; set; }
        public string CodeProduct { get; set; }
        public string  Reference   { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string DatePublication { get; set; }
        public int Qte { get; set; }
        public string? Color { get; set; }
        public string? Unity { get; set; }
        public int? Tax { get; set; }
        public float Price { get; set; }
        public int? IdPricesDelevery { get; set; }
       public int? Discount { get; set; }
       public string ImagePrincipale { get; set; }
       public string? VideoName { get; set; }
       public int IdMagasin { get; set; }
        public int IdCateg { get; set; }
        [ForeignKey("IdCateg")]
        public Categories Categories { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; }
        public int IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public Countries Countries { get; set; }
        public int IdCity { get; set; }
        [ForeignKey("IdCity")]
        public Cities Cities { get; set; }
        public int IdBrand { get; set; }
        [ForeignKey("IdBrand")]
        public Brands Brands { get; set; }
        public int? IdPrize { get; set; }
        [ForeignKey("IdPrize")]
        public Prizes? Prizes { get; set; }
        public int? IdBoost { get; set; }
        [ForeignKey("IdBoost")]
        public Boosts? Boosts { get; set; }
        public int Active { get; set; }

    }
}
