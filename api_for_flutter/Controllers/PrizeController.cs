using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_for_flutter.Services.PrizeServices;
using api_for_flutter.Models.PrizesModel;
using api_for_flutter.Services.Images_Services;

namespace api_for_flutter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrizeController : ControllerBase
    {
        private readonly IPrizeService _prizeService;
        private readonly IImageService _imageService;

        public PrizeController(IPrizeService prizeService , IImageService imageService)
        {
            _prizeService = prizeService ;
            _prizeService = prizeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrize([FromBody] CreatePrize createPrize )
        {

            var prize = await _prizeService.CreatePrize(createPrize);
            if (prize == null)
            {
                return NotFound(); 
            }

            return Ok(prize);
        }

        [HttpDelete("{idPrize}")]
        public async Task<IActionResult> DeletePrize(int idPrize)
        {
            var deletedPrize = await _prizeService.DeletePrize(idPrize);
            if (deletedPrize == null)
            {
                return NotFound(); 
            }

            return Ok(deletedPrize);
        }

        [HttpGet("{idPrize}")]
        public async Task<IActionResult> GetPrizeById(int idPrize)
        {
            var prize = await _prizeService.GetPrizeById(idPrize);
            if (prize == null)
            {
                return NotFound();
            }

            return Ok(prize);
        }

        [HttpGet("ByIdDeal/{idDeals}")]
        public async Task<IActionResult> GetPrizeByDeals(int idDeals)
        {
            var prize = await _prizeService.GetPrizeByDeals(idDeals);
            if (prize == null)
            {
                return NotFound();
            }

            return Ok(prize);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrize([FromBody] CreatePrize updatePrize,int idprize)
        {
            var prize = await _prizeService.UpdatePrize(updatePrize, idprize);
            if (prize == null)
            {
                return NotFound();
            }

            return Ok(prize);
        }
    }
}
