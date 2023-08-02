using api_for_flutter.Models.BrandsModel;
using api_for_flutter.Services.BrandsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<ActionResult<Brands>> CreateBrand(CreateBrands createBrands)
        {
            var brand = await _brandService.CreateBrand(createBrands);
           // return CreatedAtAction(nameof(GetBrandById), new { id = brand.IdBrand }, brand);
           return Ok(brand);
        }

        [HttpGet]
        public async Task<ActionResult<List<Brands>>> GetAllBrand()
        {
            var brands = await _brandService.GetAllBrand();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brands>> GetBrandById(int id)
        {
            var brand = await _brandService.GetBrandById(id);
            if (brand == null)
            {
                return NotFound("ther is no brand with this id");
            }
            return Ok(brand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Brands>> UpdateBrand(int id, CreateBrands createBrands)
        {
            var updatedBrand = await _brandService.UpdateBrand(createBrands, id);
            if (updatedBrand == null)
            {
                return NotFound("ther is no brand with this id");
            }
            return Ok(updatedBrand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brands>> DeleteBrand(int id)
        {
            var deletedBrand = await _brandService.DeleteBrand(id);
            if (deletedBrand == null)
            {
                return NotFound("ther is no brand with this id");
            }
            return Ok(deletedBrand);
        }
    }
}
