using api_for_flutter.Data;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDBContext _context;
        public CountryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async  Task<Countries> CreateCountry(CreateCountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            var c = new Countries
            {
                Title = country.Title,
                Flag = country.Flag,
                Code = country.Code,
                PhoneCode = country.PhoneCode,
                Active = country.Active,

            };

            _context.Countries.Add(c);
            _context.SaveChangesAsync();

            return c;

        }

        public List<Countries> GetCountrys()
        {
            return _context.Countries.Where(a=>a.Active==1).ToList();
        }
    }
}
