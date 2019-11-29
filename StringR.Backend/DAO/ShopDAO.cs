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
        
        /*
         *
         *    Validate
         * 
         */
        public DataSet ValidateShop(string userName, string password)
        {
            try
            {
                _dataAccessLayer.CreateParameters(2);
                _dataAccessLayer.AddParameters(0, "userId", userName);
                _dataAccessLayer.AddParameters(1, "password", password);

                return _dataAccessLayer.ExecuteDataSet("AuthenticateShop", CommandType.StoredProcedure);;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
                throw;
            }
        }
    }
}