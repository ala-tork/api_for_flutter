using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Services.CitiesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesControler : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesControler (ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cities = _cityService.GetAllCitiesByCountry(id);
            return Ok(cities);
        }

        [HttpPost("AddCity")]
        public ActionResult<Cities> AddCity(CreateCity city)
        {
            var c = _cityService.AddCity(city);
            if (c == null)
                return NotFound();
            return Ok(c);
        }

        [HttpGet("GetCityByID/{id}")]
        public IActionResult GetCityByID(int id)
        {
            var cities = _cityService.GetCityById(id);
            return Ok(cities);
        }
    }
}
