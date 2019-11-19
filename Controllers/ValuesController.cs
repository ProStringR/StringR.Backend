using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private Person _person;
        public ValuesController(IConfiguration configuration)
        {
            _person = new Person(configuration);
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var value = _person.GetAllPersons();
            return new string[] { "value1", "value2", value, value, "Marcus" };
        }

        [HttpGet("person")]
        public ActionResult<IEnumerable<string>> GetPersons()
        {
            var value = _person.GetAllPersons();
            return new string[] {value, "hahaha"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
