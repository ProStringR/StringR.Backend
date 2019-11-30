using System;
using StringR.Backend.DAO;
using StringR.Backend.DataController.Interface;
using StringR.Backend.Models;

namespace StringR.Backend.DataController
{
    public class RacketDataController : IRacketDataController
    {
        private RacketDAO _racketDAO;
        
        public RacketDataController(RacketDAO racketDAO)
        {
            _racketDAO = racketDAO;
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
        public void PostRacket(Racket racket)
        {
            try
            {
                _racketDAO.PostRacket(racket);
            }
            catch (Exception e)
            {
                throw;
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