using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_for_flutter.Models.ProductModel;
using api_for_flutter.Services.ProductServices;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            try
            {
                var data = _productService.GetProduct().ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct productModel)
        {
            if (ModelState.IsValid)
            {
                var createdProduct = await _productService.CreateProduct(productModel);
                return Ok(createdProduct);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var deletedProduct = await _productService.DeleteProductById(id);

            if (deletedProduct != null)
            {
                return Ok(deletedProduct);
            }

            return BadRequest("No product found with this ID.");
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateProduct updateProduct)
        {
            var updatedProduct = await _productService.updateProduct(updateProduct, id);

            if (updatedProduct != null)
            {
                return Ok(updatedProduct);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("ShowMoreProductByUserId")]
        public IActionResult ShowMoreProductByUserId(int iduser, int page=0, int pagesize=4)
        {
            try
            {
                var data = _productService.ShowMoreProductByIdUser(iduser, page, pagesize).ToList();
                var nbitems = _productService.NbrProductByIdUser(iduser);

                return Ok(new
                {
                    ListProducts = data,
                    NbItems = nbitems,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
