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
        
        /*
         *
         *    POST
         * 
         */

        /*
         *
         *    PUT
         * 
         */
        [HttpPut]
        public ActionResult PutRacketStringToStorage([FromBody] StringToStorageTransaction stringToStorageTransaction)
        {
            try
            {
                _racketStringDataController.PutRacketStringToStorage(stringToStorageTransaction.StringId, stringToStorageTransaction.Price, stringToStorageTransaction.TransactionDate, stringToStorageTransaction.LengthAdded);
                return Ok("Your string is now updated");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong updating the string");
            }
        }
    }
}