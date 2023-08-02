using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.BrandsModel
{
    public class Brands
    {
        [Key]
        public int IdBrand { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int Active { get; set; }
    }
}
