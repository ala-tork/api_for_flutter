using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.ProductModel;

namespace api_for_flutter.Services.ProductServices
{
    public interface IProductService
    {
        List<Product> GetProduct();
        public List<Product> ShowMore(int page = 0);
        public List<Product> ShowMoreProductByIdUser(int iduser, int page = 0, int pagesize = 4);
        Task<Product> CreateProduct(CreateProduct prod);
        Product GetProductById(int id);
        int NbrProduct();
        int NbrProductByIdUser(int iduser);
        Task<Product> DeleteProductById(int id);
        Task<Product> updateProduct(CreateProduct prod, int id);

    }
}
