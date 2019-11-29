using System;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

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
        
        public string GetStringById(int racketStringId)
        {
            try
            {
                return JsonConvert.SerializeObject(_racketStringDAO.GetStringById(racketStringId).Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetAllStringsForShop(int shopId)
        {
            try
            {
                return JsonConvert.SerializeObject(_racketStringDAO.GetAllStringsForShop(shopId).Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}