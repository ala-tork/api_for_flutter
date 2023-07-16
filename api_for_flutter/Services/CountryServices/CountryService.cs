using api_for_flutter.Data;
using api_for_flutter.Models;

namespace api_for_flutter.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDBContext _context;
        public CountryService(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<Countries> GetCountrys()
        {
            return _context.Countries.ToList();
        }
    }
}
