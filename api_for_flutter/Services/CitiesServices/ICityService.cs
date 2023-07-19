using api_for_flutter.Models.CitiesModels;

namespace api_for_flutter.Services.CitiesServices
{
    public interface ICityService
    {
        List<Cities> GetAllCitiesByCountry(int IdCountry);
        Cities AddCity(CreateCity city);
        Cities GetCityById(int id);
    }
}
