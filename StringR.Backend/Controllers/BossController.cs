using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace StringR.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BossController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Marcus", "Jaafar" };
        }

        [HttpGet("noobs")]
        public ActionResult<IEnumerable<string>> GetNoobs()
        {
            return new string[] {"Milisha", "Freddie"};
        }
    }
}