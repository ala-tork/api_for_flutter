using api_for_flutter.Models.DealsModel;
using api_for_flutter.Services.DealsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly IDealsService _dealsService;

        public DealsController(IDealsService dealsService)
        {
            _dealsService = dealsService;
        }

        [HttpGet]
        public ActionResult<List<Deals>> GetDeals()
        {
            var deals = _dealsService.GetDeals();
            return Ok(deals);
        }

        [HttpGet("showmore")]
        public ActionResult<List<Deals>> ShowMore(int page = 0)
        {
            var deals = _dealsService.ShowMore(page);
            return Ok(deals);
        }

        [HttpGet("showmore/{iduser}")]
        public ActionResult<List<Deals>> ShowMoreByIdUser(int iduser, int page = 0)
        {
            var deals = _dealsService.ShowMoreByIdUser(iduser, page);
            return Ok(deals);
        }

        [HttpPost]
        public async Task<ActionResult<Deals>> CreateDeal(CreateDeals dl)
        {
            var deal = await _dealsService.CreateDeal(dl);
            return CreatedAtAction(nameof(GetDealsById), new { id = deal.IdDeal }, deal);
        }

        [HttpGet("{id}")]
        public ActionResult<Deals> GetDealsById(int id)
        {
            var deal = _dealsService.GetDealsById(id);
            if (deal == null)
            {
                return NotFound();
            }
            return Ok(deal);
        }

        [HttpGet("nbrads")]
        public ActionResult<int> NbrAds()
        {
            var count = _dealsService.NbrAds();
            return Ok(count);
        }

        [HttpGet("nbDealsByUser/{iduser}")]
        public ActionResult<int> NbrDealsByIdUser(int iduser)
        {
            var count = _dealsService.NbrDealsByIdUser(iduser);
            return Ok(count);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Deals>> DeleteDealsById(int id)
        {
            var deal = await _dealsService.DeleteDealsById(id);
            if (deal == null)
            {
                return NotFound();
            }
            return Ok(deal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Deals>> UpdateDeals(int id, CreateDeals deal)
        {
            var updatedDeal = await _dealsService.UpdateDeals(deal, id);
            if (updatedDeal == null)
            {
                return NotFound();
            }
            return Ok(updatedDeal);
        }
    }
}
