using api_for_flutter.Data;
using api_for_flutter.Models.CitiesModels;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.CitiesServices
{
    public class CityService : ICityService
    {
        private readonly ApplicationDBContext _dbContext;
        public CityService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cities AddCity(CreateCity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            var newCity = new Cities
            {
                Title = city.Title,
                IdCountry = city.IdCountry
            };

            _dbContext.Cities.Add(newCity);
            _dbContext.SaveChanges();

            return newCity;
        }


        public List<Cities> GetAllCitiesByCountry(int IdCountry)
        {
            var cities = _dbContext.Cities.Where(c => c.IdCountry == IdCountry ).Include(c=>c.Countries).ToList();
            return cities;
        }

        public Cities GetCityById(int id)
        {
            var city = _dbContext.Cities.FirstOrDefault(c => c.IdCity == id);
            return city;
        }
    }
}
