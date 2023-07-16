using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models
{
    public class Countries
    {
        [Key]
        public int IdCountrys { get; set; }
        public string Title { get; set; }
        public string? Flag { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public int Active { get; set; }
    }
}
