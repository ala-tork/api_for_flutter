namespace api_for_flutter.Models.ProductModel
{
    public class FilterProduct
    {
        public string? productName { get; set; }
        public string? codeBar { get; set; }
        public string? codeProd { get; set; }
        public string? reference { get; set; }
        public int? IdBrans { get; set; }
        public int? IdCountrys { get; set; }
        public int? IdCity { get; set; }
        public List<int?> IdFeaturesValues { get; set; }
        public int? IdCategory { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public int PageNumber { get; set; }
    }
}
