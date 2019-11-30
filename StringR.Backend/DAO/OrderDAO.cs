using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Models;

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
        
        /*
         *
         *    POST
         * 
         */
        public void PostOrder(Order order)
        {
            _dataAccessLayer.BeginTransaction();
            try
            {
                _dataAccessLayer.CreateParameters(12);
                _dataAccessLayer.AddParameters(0, "customerId", order.customerId);
                _dataAccessLayer.AddParameters(1, "stringerId", order.stringerId);
                _dataAccessLayer.AddParameters(2, "shopId", order.shopId);
                _dataAccessLayer.AddParameters(3, "racketModel", order.racketModel);
                _dataAccessLayer.AddParameters(4, "racketBrand", order.racketBrand);
                _dataAccessLayer.AddParameters(5, "tensionVertical", order.tensionVertical);
                _dataAccessLayer.AddParameters(6, "tensionHorizontal", order.tensionHorizontal);
                _dataAccessLayer.AddParameters(7, "stringId", order.stringId);
                _dataAccessLayer.AddParameters(8, "deliveryDate", order.deliveryDate);
                _dataAccessLayer.AddParameters(9, "price", order.price);
                _dataAccessLayer.AddParameters(10, "comment", order.comment);
                _dataAccessLayer.AddParameters(11, "datePlaced", order.datePlaced);

                _dataAccessLayer.ExecuteScalar("CreateOrder", CommandType.StoredProcedure);

                _dataAccessLayer.CommitTransaction();
            }
            catch (Exception e)
            {
                _dataAccessLayer.RollbackTransaction();
                throw;
            }   
        }

        /*
         *
         *    PUT
         * 
         */
        public void PutOrder(int orderId, long transactionDate, bool paidStatus, int orderStatus)
        {
            _dataAccessLayer.BeginTransaction();
            try
            {
                _dataAccessLayer.CreateParameters(4);
                _dataAccessLayer.AddParameters(0, "orderId", orderId);
                _dataAccessLayer.AddParameters(1, "transactionDate", transactionDate);
                _dataAccessLayer.AddParameters(2, "paidStatus", paidStatus);
                _dataAccessLayer.AddParameters(3, "orderStatus", orderStatus);

                _dataAccessLayer.ExecuteScalar("UpdateOrder", CommandType.StoredProcedure);

                _dataAccessLayer.CommitTransaction();
            }
            catch (Exception e)
            {
                _dataAccessLayer.RollbackTransaction();
                throw;
            }   
        }
    }
}