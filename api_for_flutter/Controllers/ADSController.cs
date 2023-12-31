﻿using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.AdsServices;
using api_for_flutter.Services.Images_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace api_for_flutter.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly Iservices _iservices;
        public AdsController(Iservices iservices )
        {
            _iservices = iservices;
        }



        [HttpGet("ads")]
        public IActionResult GetAllAds() {
            try
            {
                var data = _iservices.GetAds().ToList();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet("ShowMoreByUser")]
        [Authorize]
        public IActionResult ShowMoreByUser(int iduser,int page,int pagesize)
        {
            var data = _iservices.ShowMoreByIdUser(iduser,page, pagesize).ToList();
            var nbitems = _iservices.NbrAdsByIdUser(iduser);
            return Ok(new
            {
                ListAds = data,
                nbitems = nbitems,

            }
            );
        }

        [HttpGet("NbrAdsByUser")]
        public IActionResult NbrAdsByIdUser(int iduser)
        {
            return Ok(_iservices.NbrAdsByIdUser(iduser));
        }

        [HttpGet("/Ad/{id}")]
        public IActionResult GetAdById(int id)
        {
            var ad = _iservices.GetAdById(id);

            if (ad == null)
            {
                return NotFound();
            }

            return Ok(ad);
        }

        [HttpPost("CreateAds")]
        public async  Task<IActionResult> CreateAd([FromForm] CreateAds adModel)
        {
            if (ModelState.IsValid )
            {
                    var x = await _iservices.CreateAdd(adModel);
                    return Ok(x);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdsById(int id)
        {
            var res = await _iservices.DeleteAdsById(id);
            if(res != null)
            {
                return Ok(res);
            }
            return BadRequest("ther is no ads With this id ");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ads>> UpdateAds(int id, CreateAds updateAds)
        {
                var res = await _iservices.updateAds(updateAds, id);
                if (res != null)
                {
                    return Ok(res);
                }
            
            return BadRequest(ModelState);
        }


    }
}
