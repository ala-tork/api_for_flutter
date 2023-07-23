using api_for_flutter.Models.CountriesModel;

namespace api_for_flutter.Services.CountryServices
{
    public interface ICountryService
    {
        List<Countries> GetCountrys();
        Task<Countries> CreateCountry(CreateCountry country);
    }
}
