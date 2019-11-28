using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class StringerDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public StringerDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }

        public DataSet GetAllStringersForShop(int shopId)
        {
            try
            {
                return _dataController.GetAllDataFromId(shopId, "GetTeamOfStringerForShop");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

//            try
//            {
//                // Call stored procedure
//                _dataAccessLayer.CreateParameters(1);
//                _dataAccessLayer.AddParameters(0, "id", 1);
//                DataSet response =
//                    _dataAccessLayer.ExecuteDataSet("GetTeamOfStringerForShop", CommandType.StoredProcedure);
//
//                return response;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("ERROR: " + e);
//                throw;
//            }
        }
    }
}