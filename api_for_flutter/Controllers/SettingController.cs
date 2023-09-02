using System;
using System.Threading.Tasks;
using api_for_flutter.Models.SettingModel;
using api_for_flutter.Services.SettingServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService ?? throw new ArgumentNullException(nameof(settingService));
        }

        // POST api/setting
        [HttpPost]
        public async Task<ActionResult<Setting>> CreateSetting([FromBody] CreateSetting setting)
        {
            try
            {
                var createdSetting = await _settingService.CreateSetting(setting);
                return CreatedAtAction(nameof(CreateSetting), new { id = createdSetting.IdSetting }, createdSetting);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/setting/nbDiamondAds
        [HttpGet("nbDiamondAds")]
        public async Task<ActionResult<int>> GetNbDiamondAds()
        {
            try
            {
                var nbDiamondAds = await _settingService.GetNbDiamondAds();
                return Ok(nbDiamondAds);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/setting/nbDiamondDeals
        [HttpGet("nbDiamondDeals")]
        public async Task<ActionResult<int>> GetNbDiamondDeals()
        {
            try
            {
                var nbDiamondDeals = await _settingService.GetNbDiamondDeals();
                return Ok(nbDiamondDeals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/setting/nbDiamondProduct
        [HttpGet("nbDiamondProduct")]
        public async Task<ActionResult<int>> GetNbDiamondProduct()
        {
            try
            {
                var nbDiamondProduct = await _settingService.GetNbDiamondProduct();
                return Ok(nbDiamondProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
