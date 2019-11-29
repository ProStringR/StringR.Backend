using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Models;
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
        
        /*
         *
         *    GET
         * 
         */

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
        
        /*
         *
         *    POST
         * 
         */

        public void PostCustomer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string userId,
            string password,
            int preferredStringTypeId,
            double preferredTensionVertical,
            double preferredTensionHorizontal)
        {
            _dataAccessLayer.BeginTransaction();

            try
            {
                _dataAccessLayer.CreateParameters(9);
                _dataAccessLayer.AddParameters(0, "firstName", firstName);
                _dataAccessLayer.AddParameters(1, "lastName", lastName);
                _dataAccessLayer.AddParameters(2, "email", email);
                _dataAccessLayer.AddParameters(3, "phoneNumber", phoneNumber);
                _dataAccessLayer.AddParameters(4, "userId", userId);
                _dataAccessLayer.AddParameters(5, "password", password);
                _dataAccessLayer.AddParameters(6, "preferredStringTypeId", preferredStringTypeId);
                _dataAccessLayer.AddParameters(7, "preferredTensionVertical", preferredTensionVertical);
                _dataAccessLayer.AddParameters(8, "preferredTensionHorizontal", preferredTensionHorizontal);

                _dataAccessLayer.ExecuteScalar("CreateCustomer", CommandType.StoredProcedure);
                
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