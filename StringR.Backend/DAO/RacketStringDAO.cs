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
        
        /*
         *
         *    POST
         * 
         */

        /*
         *
         *    PUT
         * 
         */

        public void PutRacketStringToStorage(int stringId, double price, long transactionDate, int lengthAdded)
        {
            _dataAccessLayer.BeginTransaction();

            try
            {
                _dataAccessLayer.CreateParameters(4);
                _dataAccessLayer.AddParameters(0, "stringId", stringId);
                _dataAccessLayer.AddParameters(1, "price", price);
                _dataAccessLayer.AddParameters(2, "transactionDate", transactionDate);
                _dataAccessLayer.AddParameters(3, "lengthAdded", lengthAdded);

                _dataAccessLayer.ExecuteScalar("UpdateRacketStringInStorageOnPurchase", CommandType.StoredProcedure);
                
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