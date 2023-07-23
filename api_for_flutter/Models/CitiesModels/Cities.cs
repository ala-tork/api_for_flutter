using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_for_flutter.Models.CountriesModel;

namespace api_for_flutter.Models.CitiesModels
{
    public class Cities
    {
        [Key]
        public int IdCity { get; set; }
        public string Title { get; set; }
        public int IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public Countries Countries { get; set; }
    }
}
