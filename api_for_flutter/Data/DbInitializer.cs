using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_for_flutter.Data
{
    public class DbInitializer
    {
        public static void Seed(WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                //Countries
                if (!dbContext.Countries.Any())
                {
                    var countrylist = new List<Countries>();
                    for (var i = 1; i <= 5; i++)
                    {
                        var cat = new Countries
                        {
                            Title = "Country " + i,
                            Code = "Code Country " + i,
                            PhoneCode = "+26 " + i,
                            Active = 1,
                        };
                        countrylist.Add(cat);
                    }
                    dbContext.Countries.AddRange(countrylist);
                    dbContext.SaveChanges();
                }

                //Cities
                if (!dbContext.Cities.Any())
                {
                    var citylist = new List<Cities>();
                    for (var i = 1; i <= 5; i++)
                    {
                        var city = new Cities
                        {
                            Title = "City " + i,
                            IdCountry = i,
                        };
                        citylist.Add(city);
                    }
                    dbContext.Cities.AddRange(citylist);
                    dbContext.SaveChanges();
                }



                //Categories 
                if(!dbContext.Categories.Any())
                {
                    var catlist=new List<Categories>();
                    for (var i=1;i<=5;i++)
                    {
                        var cat = new Categories
                        {
                            title ="categorie "+i,
                            description ="description "+i,
                            image ="image "+i,
                            idparent =null,
                            Active =1,
                        };
                        catlist.Add(cat);
                    }
                    dbContext.Categories.AddRange(catlist);
                    dbContext.SaveChanges();
                }
                // Ads
                if (!dbContext.Ads.Any())
                {
                    var adsList = new List<Ads>();

                    for (var i = 1; i <= 10; i++)
                    {
                        var ad = new Ads
                        {
                            //IdAds = i,
                            Title = "Ads " + i,
                            Description = "Description "+i,
                            details = "details "+i,
                            Price = 100+i,
                            ImagePrinciple ="link "+i,
                            IdCateg = 3,
                            IdCountrys =1,
                            IdCity = 1,
                            Locations ="location "+i,
                            Active =1
                        };

                        adsList.Add(ad);
                    }

                    dbContext.Ads.AddRange(adsList);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
