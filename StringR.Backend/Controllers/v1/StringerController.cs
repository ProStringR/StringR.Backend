using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StringerController : ControllerBase
    {
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Marcus", "Jaafar" };
        }
        
    }
}