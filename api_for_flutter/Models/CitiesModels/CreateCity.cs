using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.CitiesModels
{
    public class CreateCity
    {
        public string Title { get; set; }
        public int IdCountry { get; set; }
        
        
    }
}
