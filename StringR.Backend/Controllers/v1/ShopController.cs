using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        
        private IShopDataController _shopDataController;
        
        public ShopController(IConfiguration configuration)
        {
            _shopDataController = new ShopDataController(new ShopDAO(configuration));
        }
        
        /*
         *
         *    GET
         * 
         */

        [HttpGet("{shopId}")]
        public ActionResult<string> GetShopById(int shopId)
        {
            try
            {
                return _shopDataController.GetShopById(shopId);
            }
            catch (Exception e)
            {
                return BadRequest("Something went Wrong");
            }
        }
        
        /*
         *
         *    POST
         * 
         */
        [HttpPost]
        public ActionResult PostShop([FromBody] Shop shop)
        {
            try
            {
                _shopDataController.PostShop(shop);
                return Ok("The shop has been created successfully");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong creating the shop");
            }
        }

        [HttpPost("postTeamWithMember")]
        public ActionResult PostTeamToShopWithMember([FromBody] TeamToShopWithMember teamToShopWithMember)
        {
            try
            {
                _shopDataController.PostTeamToShopWithMember(teamToShopWithMember);
                return Ok("The team has been created successfully");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong creating the team");
            }
        }

    }
}