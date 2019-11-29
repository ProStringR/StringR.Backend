using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class StringerDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public StringerDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }
        
        /*
         *
         *    GET
         * 
         */

        public DataSet GetStringerById(int stringerId)
        {
            try
            {
                return _dataController.GetAllDataFromId(stringerId, "GetStringerById");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DataSet GetAllStringersForShop(int shopId)
        {
            try
            {
                return _dataController.GetAllDataFromId(shopId, "GetTeamOfStringerForShop");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}