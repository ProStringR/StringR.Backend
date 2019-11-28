using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

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
        
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return BadRequest("Not Implemented...");
        }
        
        // GET api/values
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
    }
}