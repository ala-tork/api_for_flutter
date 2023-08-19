using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_for_flutter.Models;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Data;

namespace api_for_flutter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoostSlideShowController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BoostSlideShowController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBoostedItems()
        {
            var boostedAds = await _context.Ads
                .Where(ad => ad.IdBoost.HasValue && ad.Active == 1)
                .ToListAsync();

            var boostedDeals = await _context.Deals
                .Where(deal => deal.IdBoost.HasValue && deal.Active == 1)
                .ToListAsync();

            var random = new Random();

            var boostedItems = boostedAds.Select(ad => new BoostSlideShow
            {
                BoostedId = ad.IdAds,
                ItemType = "Ad",
                Title = ad.Title,
                DatePublication=ad.DatePublication,
                Price = ad.Price,
                Locations= ad.Locations,
                ImageUrl = ad.ImagePrinciple,
                ads=ad
            })
            .Concat(boostedDeals.Select(deal => new BoostSlideShow
            {
                BoostedId = deal.IdDeal,
                ItemType = "Deal",
                Title = deal.Title,
                DatePublication=deal.DatePublication,
                Price=deal.Price,
                Locations=deal.Locations,
                DateEND=deal.DateEND,
                Discount=deal.Discount,
                ImageUrl = deal.ImagePrinciple,
                deals=deal
            }))
            .OrderBy(r => random.Next())
            .Take(10)
            .ToList();

            return Ok(boostedItems);
        }



        [HttpGet("randomNotBosted")]
        public async Task<IActionResult> GetRandomAdsDealsBoosted()
        {
            var randomdAds = await _context.Ads
                .Where(ad => ad.IdBoost.HasValue && ad.Active == 1)
                .ToListAsync();

            var randomDeals = await _context.Deals
                .Where(deal => deal.IdBoost.HasValue && deal.Active == 1)
                .ToListAsync();

            var random = new Random();

            var boostedItems = randomdAds.Select(ad => new BoostSlideShow
            {
                BoostedId = ad.IdAds,
                ItemType = "Ad",
                Title = ad.Title,
                DatePublication = ad.DatePublication,
                Price = ad.Price,
                Locations = ad.Locations,
                ImageUrl = ad.ImagePrinciple,
                ads=ad
            })
            .Concat(randomDeals.Select(deal => new BoostSlideShow
            {
                BoostedId = deal.IdDeal,
                ItemType = "Deal",
                Title = deal.Title,
                DatePublication = deal.DatePublication,
                Price = deal.Price,
                Locations = deal.Locations,
                DateEND = deal.DateEND,
                Discount = deal.Discount,
                ImageUrl = deal.ImagePrinciple,
                deals=deal
            }))
            .OrderBy(r => random.Next())
            .Take(10)
            .ToList();

            return Ok(boostedItems);
        }

    }
}
