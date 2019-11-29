using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class OrderDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public OrderDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }
        
        /*
         *
         *    GET
         * 
         */
        public DataSet GetOrderbyId(int orderId)
        {
            try
            {
                return _dataController.GetAllDataFromId(orderId, "GetOrderById");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DataSet GetAllOrdersForShop(int shopId)
        {

            try
            {
                return _dataController.GetAllDataFromId(shopId, "GetAllOrdersForShop");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public DataSet GetAllOrdersForShopOnStatus(int shopId, int orderStatus)
        {
            try
            {
                _dataAccessLayer.CreateParameters(2);
                _dataAccessLayer.AddParameters(0, "id", shopId);
                _dataAccessLayer.AddParameters(1, "stat", orderStatus);

                return _dataAccessLayer.ExecuteDataSet("GetAllOrdersForShopOnStatus", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
                throw;
            }
        }
    }
}