using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.ProductModel
{
    public class ProductsDto
    {

        public string CodeBar { get; set; }
        public string CodeProduct { get; set; }
        public string Reference { get; set; }
        public string DatePublication { get; set; }
        public int? Prize { get; set; }
        public int Categorie { get; set; }
        public int User { get; set; }
        public int? Magasin { get; set; }
        public int Brand { get; set; }
        public int Country { get; set; }
        public int? Boost { get; set; }
        public int Active { get; set; }






    }
}
