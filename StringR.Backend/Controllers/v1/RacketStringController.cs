using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.DTO;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers.v1
{
    [Authorize]
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
        public ActionResult<RacketStringDto> GetRacketStringById(int racketStringId)
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
        public ActionResult<List<RacketStringDto>> GetAllStringsForShop(int shopId)
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

        [HttpPost]
        public ActionResult PostRacketStringToStorage(RacketString racketString)
        {
            try
            {
                _racketStringDataController.PostRacketStringToStorage(racketString);
                return Ok("RacketString was successfully created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Something went wrong creating RacketString");
            }
        }

        /*
         *
         *    PUT
         * 
         */
        
        [HttpPut("shop/{stringId}")]
        public ActionResult PutRacketStringToStorage([FromBody] StringToStorageTransaction stringToStorageTransaction, int stringId)
        {
            try
            {
                _racketStringDataController.PutRacketStringToStorage(stringId, stringToStorageTransaction.Price, stringToStorageTransaction.TransactionDate, stringToStorageTransaction.LengthAdded);
                return Ok("Your string is now updated");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong updating the string");
            }
        }
        
        /*
         *
         *    Delete
         * 
         */

        [HttpDelete("delete/{stringId}")]
        public ActionResult DeleteRacketString(int stringId)
        {
            try
            {
                _racketStringDataController.DeleteRacketString(stringId);
                return Ok("String deleted softly");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}