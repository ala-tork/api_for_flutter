using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_for_flutter.Models.ProductModel;
using api_for_flutter.Data;
using api_for_flutter.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly ApplicationDBContext _dbContext;

    public ProductService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> CreateProduct(CreateProduct prod)
    {
        var product = new Product
        {
            CodeBar = prod.CodeBar,
            CodeProduct = prod.CodeProduct,
            Reference = prod.Reference,
            Title = prod.Title,
            Description = prod.Description,
            Details = prod.Details,
            DatePublication = DateTime.Now.ToString("yyyy-MM-dd"),
            Qte = prod.Qte,
            Color = prod.Color,
            Unity = prod.Unity,
            Tax = prod.Tax,
            Price = prod.Price,
            IdPricesDelevery = prod.IdPricesDelevery,
            Discount = prod.Discount,
            ImagePrincipale = prod.ImagePrincipale,
            VideoName = prod.VideoName,
            IdPrize = prod.IdPrize,
            IdCateg = prod.IdCateg,
            IdUser = prod.IdUser,
            IdMagasin = prod.IdMagasin,
            IdBrand = prod.IdBrand,
            IdCountry = prod.IdCountry,
            IdCity = prod.IdCity,
            IdBoost = prod.IdBoost,
            Active = prod.Active
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<Product> DeleteProductById(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        return product;
    }

    public List<Product> GetProduct()
    {
        return _dbContext.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.IdProd == id);
    }

    public int NbrProduct()
    {
        return _dbContext.Products.Count();
    }

    public int NbrProductByIdUser(int iduser)
    {
        return _dbContext.Products.Count(p => p.IdUser == iduser);
    }

    public List<Product> ShowMore(int page = 0)
    {
        int pageSize = 10; // Adjust as needed
        int skip = page * pageSize;

        return _dbContext.Products.Skip(skip).Take(pageSize).ToList();
    }

    public List<Product> ShowMoreProductByIdUser(int iduser, int page = 0, int pageSize = 4)
    {
        int skip = page * pageSize;

        return _dbContext.Products
            .Where(p => p.IdUser == iduser)
            .Skip(skip)
            .Take(pageSize)
            .ToList();
    }

    public async Task<Product> updateProduct(CreateProduct prod, int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product != null)
        {
            product.CodeBar = prod.CodeBar;
            product.CodeProduct = prod.CodeProduct;
            product.Reference = prod.Reference;
            product.Title = prod.Title;
            product.Description = prod.Description;
            product.Discount = prod.Discount;
            product.Details = prod.Details;
            product.DatePublication = DateTime.Now.ToString("yyyy-MM-dd");
            product.Qte = prod.Qte;
            product.Color = prod.Color;
            product.Unity = prod.Unity;
            product.Tax = prod.Tax;
            product.Price = prod.Price;
            product.IdPricesDelevery = prod.IdPricesDelevery;
            product.Discount = prod.Discount;
            product.ImagePrincipale = prod.ImagePrincipale;
            product.VideoName = prod.VideoName;
            product.IdPrize = prod.IdPrize;
            product.IdCateg = prod.IdCateg;
            product.IdUser = prod.IdUser;
            product.IdMagasin = prod.IdMagasin;
            product.IdBrand = prod.IdBrand;
            product.IdCountry = prod.IdCountry;
            product.IdCity = prod.IdCity;
            product.IdBoost = prod.IdBoost;
            product.Active = prod.Active;

            await _dbContext.SaveChangesAsync();
        }

        return product;
    }
}
