using System;
using System.Data;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

namespace StringR.Backend.DataController
{
    public class StringerDataController : IStringerDataController
    {

        private StringerDAO _stringerDAO;
        
        public StringerDataController(StringerDAO stringerDAO)
        {
            _stringerDAO = stringerDAO;
        }
        
        /*
         *
         *    GET
         * 
         */

        public string GetStringerById(int stringerId)
        {

            try
            {
                return JsonConvert.SerializeObject(_stringerDAO.GetStringerById(stringerId).Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public string GetAllStringersForShop(int shopId)
        {
            DataSet dataSet;

            try
            {
                dataSet = _stringerDAO.GetAllStringersForShop(shopId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return JsonConvert.SerializeObject(dataSet.Tables[0]);
        }
    }
}