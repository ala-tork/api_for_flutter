using api_for_flutter.Models.CategoryModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api_for_flutter.Models.FeaturesValuesModel;

namespace api_for_flutter.Models.FeaturesModels
{
    public class FeaturesWithListValues
    {
        [Key]
        public int IdF { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Unit { get; set; }
        public int Active { get; set; }

        public int idCategory { get; set; }
        [ForeignKey("idCategory")]
        public Categories? Categorie { get; set; }
        public List<FeaturesValues> ValuesList { get; set; }
    }
}
