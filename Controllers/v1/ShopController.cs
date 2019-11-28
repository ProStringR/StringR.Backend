using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

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

    }
}