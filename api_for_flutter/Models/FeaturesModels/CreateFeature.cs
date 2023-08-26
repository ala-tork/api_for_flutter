using api_for_flutter.Models.CategoryModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_for_flutter.Models.FeaturesModels
{
    public class CreateFeature
    {

        public string Title { get; set; }
        public string? Description { get; set; }
        public string Unit { get; set; }
        public int Active { get; set; }
        //public int idCategory { get; set; }

    }
}
