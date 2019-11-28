using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Utility;

namespace StringR.Backend.DAO
{
    public class CustomerDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public CustomerDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }

        public DataSet GetAllCustomers()
        {
            try
            {
                return _dataAccessLayer.ExecuteDataSet("GetAllCustomers", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DataSet GetCustomerById(int customerId)
        {
            try
            {
                return _dataController.GetAllDataFromId(customerId, "GetCustomerById");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}