using api_for_flutter.Models.WinnersModel;
using api_for_flutter.Services.WinnersServices;
using Microsoft.AspNetCore.Mvc;



namespace api_for_flutter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WinnersController : ControllerBase
    {
        private readonly IWinnerService _servce;
        public WinnersController(IWinnerService servce)
        {
            _servce = servce;
        }

        [HttpGet("AllWinners")]
        public IActionResult GetAllWinners() 
        {
            var res=  _servce.getWinners();
            return Ok(res);
        }


        [HttpPost("AddWinner")]
        public IActionResult AddWinners([FromQuery]CreateWinner createWinner)
        {
            if (createWinner == null)
            {
                return BadRequest("Invalid Winner !");
            }
            var res = _servce.CreateWinner(createWinner);
            return Ok(res);
        }

    }

}
