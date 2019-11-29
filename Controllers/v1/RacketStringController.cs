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
    public class RacketStringController : ControllerBase
    {
        
        private IRacketStringDataController _racketStringDataController;
        
        public RacketStringController(IConfiguration configuration)
        {
            _racketStringDataController = new RacketStringDataController(new RacketStringDAO(configuration));
        }
        
        /*
         *
         *    GET
         * 
         */

        [HttpGet("{racketStringId}")]
        public ActionResult<string> GetRacketStringById(int racketStringId)
        {
            try
            {
                return _racketStringDataController.GetStringById(racketStringId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("shop/{shopId}")]
        public ActionResult<string> GetAllStringsForShop(int shopId)
        {
            try
            {
                return _racketStringDataController.GetAllStringsForShop(shopId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Something went wrong");
            }
        }
    }
}