using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StringR.Backend.DataController;
using StringR.Backend.DAO;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StringerController : ControllerBase
    {

        private StringerDataController _stringerDataController;
        
        public StringerController(IConfiguration configuration)
        {
            _stringerDataController = new StringerDataController(new StringerDAO(configuration));
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                return _stringerDataController.GetAllStringersForShop(1);
            }
            catch (Exception e)
            {
                return BadRequest("Failed...");

            }
        }
        
    }
}