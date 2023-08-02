using api_for_flutter.Data;
using api_for_flutter.Models.BrandsModel;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.BrandsServices
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDBContext _dbContext;
        public BrandService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<Brands> CreateBrand(CreateBrands createBrands)
        {
            var brand = new Brands
            {
                Title = createBrands.Title,
                Description = createBrands.Description,
                Image = createBrands.Image,
                Active = createBrands.Active,
            };
            var res = await _dbContext.Brands.AddAsync(brand);
            await _dbContext.SaveChangesAsync();
            return brand;
        }

        public async Task<Brands> DeleteBrand(int idbrand)
        {
            var brand = await _dbContext.Brands.Where(b => b.IdBrand == idbrand).FirstOrDefaultAsync();
            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync();
                return brand;
            }
            return null;
        }


        public async Task<List<Brands>> GetAllBrand()
        {
            var res = await _dbContext.Brands.ToListAsync();
            return res;
        }


        public async Task<Brands> GetBrandById(int idbrand)
        {
            var res = await _dbContext.Brands.Where(b=> b.IdBrand ==idbrand).FirstOrDefaultAsync();
            return res;
        }

        public async Task<Brands> UpdateBrand(CreateBrands createBrands, int idbrand)
        {
            var brand = await _dbContext.Brands.FirstOrDefaultAsync(b => b.IdBrand == idbrand);

            if (brand != null)
            {
                brand.Title = createBrands.Title;
                brand.Description = createBrands.Description;
                brand.Image = createBrands.Image;
                brand.Active = createBrands.Active;

                await _dbContext.SaveChangesAsync();

                return brand;
            }
            return null;
        }

    }
}
