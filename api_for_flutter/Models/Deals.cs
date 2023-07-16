using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_for_flutter.Models.CategoryModels;

namespace api_for_flutter.Models
{
    public class Deals
    {
        [Key]
       public int IdDeal { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
       public string Details { get; set; }
       public Double Price { get; set; }
       public int Discount { get; set; }
       public int Quantity { get; set; }

       //public int IdPricesDelevery { get; set; }
       //public string DatePublication { get; set; }
       //public string DateEND { get; set; }
       public string ImagePrinciple { get; set; }
       public string? VideoName { get; set; }
        public int IdCateg { get; set; }
        [ForeignKey("IdCateg")]
        public Categories Categories { get; set; }
        //public int IdUser { get; set; }
        public int IdCountrys { get; set; }
        [ForeignKey("IdCountry")]
        public Countries Countries { get; set; }
        public int IdCity { get; set; }
        [ForeignKey("IdIdCity")]
        public Cities Cities { get; set; }
        //public int IdUser { get; set; }
        //public int IdMagasin { get; set; }
        public int IdBrand { get; set; }
        [ForeignKey("IdBrand")]
        public Brands Brands { get; set; }
       //public int IdPrize { get; set; }
       public string Locations { get; set; }
       //public int IdBoost { get; set; }
       public int Active { get; set; }
    }
}
