using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class RacketStringDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public RacketStringDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }
        
        /*
         *
         *    GET
         * 
         */

        public DataSet GetStringById(int racketStringId)
        {
            try
            {
                return _dataController.GetAllDataFromId(racketStringId, "GetStringById");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DataSet GetAllStringsForShop(int shopId)
        {
            try
            {
                return _dataController.GetAllDataFromId(shopId, "GetAllStringForShop");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}