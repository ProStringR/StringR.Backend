using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class StaticDataDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;

        public StaticDataDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }

        public DataSet GetAllColors()
        {
            try
            {
                return _dataAccessLayer.ExecuteDataSet("GetAllColors", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public DataSet GetAllPurposes()
        {
            try
            {
                return _dataAccessLayer.ExecuteDataSet("GetAllPurposes", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public DataSet GetAllRacketBrands()
        {
            try
            {
                return _dataAccessLayer.ExecuteDataSet("GetAllRacketBrands", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public DataSet GetAllStringBrands()
        {
            try
            {
                return _dataAccessLayer.ExecuteDataSet("GetAllStringBrands", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}