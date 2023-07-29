using api_for_flutter.Data;
using api_for_flutter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TestController(ApplicationDBContext context)
        {
            _context = context;
        }


        /** filter the ads by price (min,max) country category city and features*/
        [HttpPost("filtered")]
        public IActionResult GetFilteredAds([FromBody] AdsFilter filter)
        {
            var query = _context.Ads.AsQueryable();

            if (filter.IdCountrys.HasValue)
                query = query.Where(a => a.IdCountrys == filter.IdCountrys);

            if (filter.IdCity.HasValue)
                query = query.Where(a => a.IdCity == filter.IdCity);

            if (filter.IdCategory.HasValue)
                query = query.Where(a => a.IdCateg == filter.IdCategory);

            if (filter.MinPrice.HasValue)
                query = query.Where(a => a.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(a => a.Price <= filter.MaxPrice.Value);

            if (filter.IdFeaturesValues != null && filter.IdFeaturesValues.Any())
                query = query.Where(a => _context.AdsFeatures
                                            .Where(af => filter.IdFeaturesValues.Contains(af.IdFeaturesValues))
                                            .Select(af => af.IdAds)
                                            .Contains(a.IdAds));



            int totalItems = query.Count();

            var pageSize = 4;

            if (filter.PageNumber == 0) {
                filter.PageNumber = 1; 
            }

            var paginatedAds = query.Include(a=>a.Categories).Include(a=>a.Countries).Include(a=>a.Cities).Where(a=>a.Active==1)
                .Skip((filter.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = filter.PageNumber,
                PageSize = pageSize,
                Ads = paginatedAds
            });
        }

    }
}
