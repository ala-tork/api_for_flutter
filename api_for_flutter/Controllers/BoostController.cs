using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_for_flutter.Models.BootsModel;
using api_for_flutter.Services.BoostServices;

namespace api_for_flutter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoostController : ControllerBase
    {
        private readonly IBoostService _boostService;

        public BoostController(IBoostService boostService)
        {
            _boostService = boostService;
        }

        [HttpPost]
        public async Task<ActionResult<Boosts>> CreateBoost(CreateBoost createBoost)
        {
            var newBoost = await _boostService.CreateBoost(createBoost);
            return CreatedAtAction(nameof(GetBoostById), new { id = newBoost.IdBoost }, newBoost);
        }

        [HttpGet]
        public async Task<ActionResult<List<Boosts>>> GetAllBoosts()
        {
            var boosts = await _boostService.GetAllBoosts();
            return Ok(boosts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Boosts>> GetBoostById(int id)
        {
            var boost = await _boostService.GetBoostById(id);
            if (boost == null)
                return NotFound("Ther is No Boost with this id");

            return Ok(boost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Boosts>> UpdateBoost(int id, CreateBoost updateBoost)
        {
            var updatedBoost = await _boostService.UpdateBoost(updateBoost, id);
            if (updatedBoost == null)
                return NotFound();

            return Ok(updatedBoost);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boosts>> DeleteBoost(int id)
        {
            var deletedBoost = await _boostService.DeleteBoost(id);
            if (deletedBoost == null)
                return NotFound();

            return Ok(deletedBoost);
        }
    }
}
