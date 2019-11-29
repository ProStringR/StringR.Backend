using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StringerController : ControllerBase
    {

        private IStringerDataController _stringerDataController;
        
        public StringerController(IConfiguration configuration)
        {
            _stringerDataController = new StringerDataController(new StringerDAO(configuration));
        }
        
        /*
         *
         *    GET
         * 
         */
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return BadRequest("Not Implemented...");
        }
        
        [HttpGet("{stringerId}")]
        public ActionResult<string> GetStringerById(int stringerId)
        {
            try
            {
                return _stringerDataController.GetStringerById(stringerId);
            }
            catch (Exception e)
            {
                return BadRequest("Failed...");

            }
        }

        [HttpGet("shop/{shopId}")]
        public ActionResult<string> GetStringersForShop(int shopId)
        {
            try
            {
                return _stringerDataController.GetAllStringersForShop(shopId);
            }
            catch (Exception e)
            {
                return BadRequest("Failed...");

            }
        }
        
        /*
         *
         *    POST
         * 
         */
        [HttpPost]
        public ActionResult PostStringerToTeam([FromBody] StringerToTeam stringerToTeam)
        {
            try
            {
                _stringerDataController.PostStringerToTeam(stringerToTeam.TeamId, stringerToTeam.Firstname, stringerToTeam.LastName, stringerToTeam.PhoneNumber, stringerToTeam.Email, stringerToTeam.PreferredRacketType);
                return Ok("The stringer has been successfully added to the team");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong adding the stringer to the team");
            }
        }
    }
}