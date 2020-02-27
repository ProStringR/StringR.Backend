using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Models;

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

        public void PostRacketStringToStorage(RacketString racketString)
        {
            _dataAccessLayer.BeginTransaction();

            try
            {
                _dataAccessLayer.CreateParameters(11);
                _dataAccessLayer.AddParameters(0, "shopId", racketString.ShopId);
                _dataAccessLayer.AddParameters(1, "length", racketString.Length);
                _dataAccessLayer.AddParameters(2, "pricePerRacket", racketString.PricePerRacket);
                _dataAccessLayer.AddParameters(3, "model", racketString.Model);
                _dataAccessLayer.AddParameters(4, "stringType", racketString.StringType);
                _dataAccessLayer.AddParameters(5, "brand", racketString.Brand);
                _dataAccessLayer.AddParameters(6, "thickness", racketString.Thickness);
                _dataAccessLayer.AddParameters(7, "purpose", racketString.Purpose);
                _dataAccessLayer.AddParameters(8, "color", racketString.Color);
                _dataAccessLayer.AddParameters(9, "price", racketString.Price);
                _dataAccessLayer.AddParameters(10, "datePlaced", racketString.DatePlaced);

                _dataAccessLayer.ExecuteScalar("AddRacketStringToStorageForShop", CommandType.StoredProcedure);
                
                _dataAccessLayer.CommitTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _dataAccessLayer.RollbackTransaction();
                throw;
            }
        }

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
                Console.WriteLine(e);
                _dataAccessLayer.RollbackTransaction();
                throw;
            }
        }
    }
}