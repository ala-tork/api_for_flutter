using api_for_flutter.Models.WinnersModel;
using api_for_flutter.Services.WinnersServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnersController : ControllerBase
    {
        private readonly IWinnerService _service;

        public WinnersController(IWinnerService servce)
        {
            _service = servce;
        }

        [HttpGet("AllWinners")]
        public async Task<IActionResult> GetAllWinners()
        {
            var res = await _service.getWinners();
            return Ok(res);
        }

        [HttpGet("RandomWinners")]
        public async Task<IActionResult> GetRandomWinners()
        {
            var randomWinners = await _service.GetRandomWinners();
            return Ok(randomWinners);
        }

        [HttpPost("AddWinner")]
        public async Task<IActionResult> AddWinner([FromQuery] CreateWinner createWinner)
        {
            if (createWinner == null)
            {
                return BadRequest("Invalid Winner!");
            }

            var res = await _service.CreateWinner(createWinner);
            return Ok(res);
        }


    }
}
