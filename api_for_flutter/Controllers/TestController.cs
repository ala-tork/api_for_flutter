using api_for_flutter.Data;
using api_for_flutter.Models;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Services.LikeServices;
using api_for_flutter.Services.WishListServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

using Formatting = Newtonsoft.Json.Formatting;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILikeService _likeService;
        private readonly IWishListService _wishListService;
        private readonly IConfiguration _configuration;
        public TestController(ApplicationDBContext context, IConfiguration _configuration,ILikeService likeService,IWishListService wishListService)
        {
            this._configuration = _configuration;
            _context = context;
            _likeService = likeService;
            _wishListService = wishListService;
        }


        /** filter the ads by price (min,max) country category city and features  and name */
        [HttpPost("filtered")]
        public IActionResult GetFilteredAds([FromBody] AdsFilter filter)
        {
            var query = _context.Ads.AsQueryable();

            if (!string.IsNullOrEmpty(filter.adsName))
            {
                var adsNameLower = filter.adsName.ToLower();
                query = query.Where(a => a.Title.ToLower().Contains(adsNameLower) && a.Active==1);
            }

            if (filter.IdCountrys.HasValue)
                query = query.Where(a => a.IdCountrys == filter.IdCountrys && a.Active == 1);

            if (filter.IdCity.HasValue)
                query = query.Where(a => a.IdCity == filter.IdCity);

            if (filter.IdCategory.HasValue)
                query = query.Where(a => a.IdCateg == filter.IdCategory);

            if (filter.MinPrice.HasValue)
                query = query.Where(a => a.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(a => a.Price <= filter.MaxPrice.Value);

            if (filter.IdFeaturesValues != null && filter.IdFeaturesValues.Any())
            {
                foreach (var featureValue in filter.IdFeaturesValues)
                {
                    //idadsfiturevalue
                    query = query.Where(a => _context.AdsFeatures
                        .Where(af => af.IdAds == a.IdAds && af.IdFeaturesValues == featureValue)
                        .Any());
                }
            }

            int totalItems = query.Count();

            var pageSize = 4;

            if (filter.PageNumber == 0)
            {
                filter.PageNumber = 1;
            }

            var paginatedAds = query
               // .Include(a => a.Categories)
               // .Include(a => a.Countries)
                //.Include(a => a.Cities)
                .Where(a => a.Active == 1)
                .Skip((filter.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = filter.PageNumber,
                PageSize = pageSize,
                Ads = paginatedAds
            }
            );
        }


        /*  [HttpPost("filtered")]
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
          }*/


        /** filter the Deals  by price (min,max) country category city and features*/
        [HttpPost("Dealsfilter")]
        public IActionResult GetFilteredDeals([FromBody] DealsFilter filter)
        {
            var query = _context.Deals.AsQueryable();

            if (!string.IsNullOrEmpty(filter.DealsName))
            {
                var dealsNameLower = filter.DealsName.ToLower();
                query = query.Where(d => d.Title.ToLower().Contains(dealsNameLower));
            }

            if (filter.IdCountrys.HasValue)
                query = query.Where(d => d.IdCountrys == filter.IdCountrys);

            if (filter.IdCity.HasValue)
                query = query.Where(d => d.IdCity == filter.IdCity);

            if (filter.IdCategory.HasValue)
                query = query.Where(d => d.IdCateg == filter.IdCategory);

            if (filter.IdBrans.HasValue)
                query = query.Where(d => d.IdBrand == filter.IdBrans);

            if (filter.MinPrice.HasValue)
                query = query.Where(d => d.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(d => d.Price <= filter.MaxPrice.Value);

            if (filter.IdFeaturesValues != null && filter.IdFeaturesValues.Any())
            {
                foreach (var featureValue in filter.IdFeaturesValues)
                {
                    query = query.Where(a => _context.AdsFeatures
                        .Where(af => af.IdDeals == a.IdDeal && af.IdFeaturesValues == featureValue)
                        .Any());
                }
            }

            int totalItems = query.Count();
            var pageSize = 4;
            if (filter.PageNumber == 0)
            {
                filter.PageNumber = 1;
            }

            var paginatedAds = query.Include(d => d.Categories)
                //.Include(d => d.Countries)
               // .Include(d => d.Cities)
               // .Include(d=>d.Brands) 
                //.Include(d => d.Categories)
                //.Include(d => d.Prizes)
                .Where(d => d.Active == 1)
                .Skip((filter.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = filter.PageNumber,
                PageSize = pageSize,
                Deals = paginatedAds
            });
        }


        [HttpGet("getuser")]
        public IActionResult GetUsersBySgbd(int pageNumber = 1, int pageSize = 10)
        {
            try
            {

                DataTable table = new DataTable();
                string SqlDataSource = _configuration.GetConnectionString("localDb");
                string query = @"usp_GetUsers";
                using (SqlConnection myconn = new SqlConnection(SqlDataSource))
                {
                    myconn.Open();
                    using (SqlCommand mycommand = new SqlCommand(query, myconn))
                    {
                        mycommand.CommandType = CommandType.StoredProcedure;
                        mycommand.CommandText = "usp_GetUsers";




                        mycommand.Parameters.Add("@PageNumber", SqlDbType.Int).Value = pageNumber;
                        mycommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                        using (SqlDataReader myReader = mycommand.ExecuteReader())
                        {
                            table.Load(myReader);
                        }
                    }


                    string json = JsonConvert.SerializeObject(table, Formatting.Indented);
                    return Content(json, "application/json");
                    //return Ok(JsonResult(table));
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

















        [HttpPost("DealsWithLikeAndWishList")]
        public async Task<IActionResult> DealsWithLikeAndWishList([FromBody] DealsFilter filter,int iduser)
        {
            var query = _context.Deals.AsQueryable();

            if (!string.IsNullOrEmpty(filter.DealsName))
            {
                var dealsNameLower = filter.DealsName.ToLower();
                query = query.Where(d => d.Title.ToLower().Contains(dealsNameLower));
            }

            if (filter.IdCountrys.HasValue)
                query = query.Where(d => d.IdCountrys == filter.IdCountrys);

            if (filter.IdCity.HasValue)
                query = query.Where(d => d.IdCity == filter.IdCity);

            if (filter.IdCategory.HasValue)
            {

                var categoryIds = new List<int> { filter.IdCategory.Value };
                var categoryStack = new Stack<int>(new[] { filter.IdCategory.Value });
                while (categoryStack.Count > 0)
                {
                    var categoryId = categoryStack.Pop();
                    var children = await _context.Categories
                        .Where(c => c.idparent == categoryId)
                        .Select(c => c.IdCateg)
                        .ToListAsync();
                    categoryIds.AddRange(children);
                    foreach (var child in children)
                    {
                        categoryStack.Push(child);
                    }
                }

                query = query.Where(d => categoryIds.Contains(d.IdCateg));
                

            }
                //query = query.Where(d => d.IdCateg == filter.IdCategory);

            if (filter.IdBrans.HasValue)
                query = query.Where(d => d.IdBrand == filter.IdBrans);

            if (filter.MinPrice.HasValue)
                query = query.Where(d => d.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(d => d.Price <= filter.MaxPrice.Value);

            if (filter.IdFeaturesValues != null && filter.IdFeaturesValues.Any())
            {
                foreach (var featureValue in filter.IdFeaturesValues)
                {
                    query = query.Where(a => _context.AdsFeatures
                        .Where(af => af.IdDeals == a.IdDeal && af.IdFeaturesValues == featureValue)
                        .Any());
                }
            }

            int totalItems = query.Count();
            var pageSize = 4;
            if (filter.PageNumber == 0)
            {
                filter.PageNumber = 1;
            }

            List<ViewDeals> paginatedAds = await query
                //.Include(d => d.Categories)
               // .Include(d => d.Countries)
               // .Include(d => d.Cities)
               // .Include(d => d.Brands)
              //  .Include(d => d.Categories)
              //  .Include(d => d.Prizes)
                .Where(d => d.Active == 1)
                .Skip((filter.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new ViewDeals
                {
                    IdDeal = d.IdDeal,
                    Title = d.Title,
                    Description = d.Description,
                    Details = d.Details,
                    Price = d.Price,
                    Discount = d.Discount,
                    Quantity = d.Quantity,
                    IdPricesDelevery = d.IdPricesDelevery,
                    DatePublication = d.DatePublication,
                    DateEND = d.DateEND,
                    ImagePrinciple = d.ImagePrinciple,
                    VideoName = d.VideoName,
                    IdCateg = d.IdCateg,
                    Categories = d.Categories,
                    IdUser = d.IdUser,
                    //user = d.user, 
                    IdCountrys = d.IdCountrys,
                    //Countries = d.Countries,
                    IdCity = d.IdCity,
                   // Cities = d.Cities,
                    IdBrand = d.IdBrand,
                    Brands = d.Brands,
                    IdPrize = d.IdPrize,
                    //Prizes = d.Prizes,
                    Locations = d.Locations,
                    IdBoost = d.IdBoost,
                    Active = d.Active,
                })
                .ToListAsync();

            foreach (var item in paginatedAds)
            {
                var likesForDeal = await _likeService.GetLikeByIdDeal(item.IdDeal);
                int likeCount = likesForDeal?.Count(l => l.IdDeal == item.IdDeal) ?? 0;
                item.NbLike = likeCount;
                var liked= await _likeService.GetLikeByIdUserIdDeal(iduser, item.IdDeal);
                if(liked != null)
                {
                    item.IdLike = liked.IdLP;
                }

                var wishList = await _wishListService.GetWishListByIdUserIdDeal(iduser, item.IdDeal);
                if(wishList != null)
                {
                    item.IdWishList = wishList.Idwish;
                }
               // else { item.IdWishList = null; }
                
            }

            return Ok(new
            {
                TotalItems = totalItems,
                PageNumber = filter.PageNumber,
                PageSize = pageSize,
                Deals = paginatedAds
            });
        }



        /** Ads */

        [HttpPost("AdsWithLikeAndWishList")]
        [Authorize]
        public async Task<IActionResult> AdsWithLikeAndWishList([FromBody] AdsFilter filter, int iduser)
        {
            var query = _context.Ads.AsQueryable();

            if (!string.IsNullOrEmpty(filter.adsName))
            {
                var adsNameLower = filter.adsName.ToLower();
                query = query.Where(a => a.Title.ToLower().Contains(adsNameLower));
            }

            if (filter.IdCountrys.HasValue)
                query = query.Where(a => a.IdCountrys == filter.IdCountrys);

            if (filter.IdCity.HasValue)
                query = query.Where(a => a.IdCity == filter.IdCity);

            if (filter.IdCategory.HasValue)
            {
                var categoryIds = new List<int> { filter.IdCategory.Value };
                var categoryStack = new Stack<int>(new[] { filter.IdCategory.Value });
                while (categoryStack.Count > 0)
                {
                    var categoryId = categoryStack.Pop();
                    var children = await _context.Categories
                        .Where(c => c.idparent == categoryId)
                        .Select(c => c.IdCateg)
                        .ToListAsync();
                    categoryIds.AddRange(children);
                    foreach (var child in children)
                    {
                        categoryStack.Push(child);
                    }
                }

                query = query.Where(a => categoryIds.Contains(a.IdCateg));


            }

            //if (filter.IdCategory.HasValue)
            //query = query.Where(a => a.IdCateg == filter.IdCategory);

            if (filter.MinPrice.HasValue)
                query = query.Where(a => a.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(a => a.Price <= filter.MaxPrice.Value);

            if (filter.IdFeaturesValues != null && filter.IdFeaturesValues.Any())
            {
                foreach (var featureValue in filter.IdFeaturesValues)
                {
                    query = query.Where(a => _context.AdsFeatures
                        .Where(af => af.IdAds == a.IdAds && af.IdFeaturesValues == featureValue)
                        .Any());
                }
            }

            int totalItems = query.Count();

            var pageSize = 4;

            if (filter.PageNumber == 0)
            {
                filter.PageNumber = 1;
            }

            List<AdsView> paginatedAds = await  query
                //.Include(a => a.Categories)
                //.Include(a => a.Countries)
               // .Include(a => a.Cities)
                .Where(a => a.Active == 1)
                .Skip((filter.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new AdsView
                {
                    IdAds = d.IdAds,
                    Title = d.Title,
                    Description = d.Description,
                    details = d.details,
                    Price = d.Price,
                    //IdPricesDelevery = d.IdPricesDelevery,
                    DatePublication = d.DatePublication,
                    ImagePrinciple = d.ImagePrinciple,
                    VideoName = d.VideoName,
                    IdCateg = d.IdCateg,
                    Categories = d.Categories,
                    IdUser = d.IdUser,
                    user = d.user,
                    IdCountrys = d.IdCountrys,
                    Countries = d.Countries,
                    IdCity = d.IdCity,
                    Cities = d.Cities,
                    Locations = d.Locations,
                    IdBoost = d.IdBoost,
                    Active = d.Active,
                })
                .ToListAsync();

            foreach (var item in paginatedAds)
            {
                var likesForDeal = await _likeService.GetLikeByIdAd(item.IdAds);
                int likeCount = likesForDeal?.Count() ?? 0;
                item.NbLike = likeCount;
                var liked = await _likeService.GetLikeByIdUserIdAd(iduser, item.IdAds);
                if (liked != null)
                {
                    item.IdLike = liked.IdLP;
                }

                var wishList = await _wishListService.GetWishListByIdUserIdAd(iduser, item.IdAds);
                if (wishList != null)
                {
                    item.IdWishList = wishList.Idwish;
                }

            }

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
