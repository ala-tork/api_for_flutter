using api_for_flutter.Services.CountryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryControler : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryControler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet("Countrys")]
        public IActionResult GetCountrys()
        {
            var data =  _countryService.GetCountrys();
            return Ok(data);

        }
    }
}
