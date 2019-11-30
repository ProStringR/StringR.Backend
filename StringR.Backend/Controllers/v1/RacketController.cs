using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DAO;
using StringR.Backend.DataController;
using StringR.Backend.DataController.Interface;
using StringR.Backend.Models;

namespace StringR.Backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RacketController : ControllerBase
    {
        private IRacketDataController _racketDataController;
        
        public RacketController(IConfiguration configuration)
        {
            _racketDataController = new RacketDataController(new RacketDAO(configuration));
        }
        /*
         *
         *    GET
         * 
         */
    
        /*
         *
         *    POST
         * 
         */
        [HttpPost]
        public ActionResult PostRacket([FromBody] Racket racket)
        {
            try
            {
                _racketDataController.PostRacket(racket);
                return Ok("The racket is saved successfully");
            }
            catch (Exception e)
            {
                return NotFound("Something went wrong saving the racket");
            }
        }


        /*
         *
         *    PUT
         * 
         */
    
        /*
         *
         *    DELETE
         * 
         */
    }
}