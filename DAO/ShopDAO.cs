using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class ShopDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public ShopDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }
        
        /*
         *
         *    GET
         * 
         */

        public DataSet GetShopById(int shopId)
        {
            try
            {
                return _dataController.GetAllDataFromId(shopId, "GetShopById");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}