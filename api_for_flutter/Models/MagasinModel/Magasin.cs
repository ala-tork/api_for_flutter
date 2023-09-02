using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.MagasinModel
{
    public class Magasin
    {
        [Key]
        public int IdMagasin { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ActivitySection { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public int IdCountry { get; set; }

        public int IdCity { get; set; }
        public string Location { get; set; }
        public int IdUser { get; set; }
        public int Active { get; set; }
    }
}
