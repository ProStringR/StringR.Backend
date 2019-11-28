using System;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

namespace StringR.Backend.DataController
{
    public class StringerDataController : StringerDataInterface
    {

        private StringerDAO _stringerDAO;
        
        public StringerDataController(StringerDAO stringerDAO)
        {
            _stringerDAO = stringerDAO;
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