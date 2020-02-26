using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.DTO;

namespace StringR.Backend.DataController
{
    public class RacketStringDataController : IRacketStringDataController
    {
        
        private RacketStringDAO _racketStringDAO;
        
        public RacketStringDataController(RacketStringDAO racketStringDAO)
        {
            _racketStringDAO = racketStringDAO;
        }
        
        /*
         *
         *    GET
         * 
         */
        
        public RacketStringDto GetStringById(int racketStringId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_racketStringDAO.GetStringById(racketStringId).Tables[0]);
                List<RacketStringDto> racketStringDtos = JsonConvert.DeserializeObject<List<RacketStringDto>>(json);
                
                // No null check because error is thrown
                // in case the user does not exist
                return racketStringDtos[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<RacketStringDto> GetAllStringsForShop(int shopId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_racketStringDAO.GetAllStringsForShop(shopId).Tables[0]);
                List<RacketStringDto> racketStringDtos = JsonConvert.DeserializeObject<List<RacketStringDto>>(json);

                return racketStringDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*
         *
         *    PUT
         * 
         */

        public void PutRacketStringToStorage(int stringId, double price, long transactionDate, int lengthAdded)
        {
            try
            {
                _racketStringDAO.PutRacketStringToStorage(stringId, price, transactionDate, lengthAdded);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}