namespace api_for_flutter.Models.ProductModel
{
    public class CreateProduct
    {
        public string CodeBar { get; set; }
        public string CodeProduct { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? DatePublication { get; set; }
        public int Qte { get; set; }
        public string? Color { get; set; }
        public string? Unity { get; set; }
        public int? Tax { get; set; }
        public float Price { get; set; }
        public int? IdPricesDelevery { get; set; }
        public int? Discount { get; set; }
        public string ImagePrincipale { get; set; }
        public string? VideoName { get; set; }
        public int? IdPrize { get; set; }
        public int IdCateg { get; set; }
        public int IdUser { get; set; }
        public int IdMagasin { get; set; }
        public int IdBrand { get; set; }
        public int IdCountry { get; set; }
        public int IdCity { get; set; }

        public int? IdBoost { get; set; }
        public int Active { get; set; }
    }
}
