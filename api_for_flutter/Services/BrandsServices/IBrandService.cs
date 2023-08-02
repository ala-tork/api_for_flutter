using api_for_flutter.Models.BrandsModel;

namespace api_for_flutter.Services.BrandsServices
{
    public interface IBrandService
    {
        Task<Brands> CreateBrand(CreateBrands createBrands);
        Task<Brands> UpdateBrand(CreateBrands createBrands , int idbrand);
        Task<Brands> DeleteBrand(int idbrand);
        Task<List<Brands>> GetAllBrand();
        Task<Brands> GetBrandById(int idbrand);
    }
}
