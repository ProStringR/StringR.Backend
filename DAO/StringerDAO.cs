using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;

namespace StringR.Backend.DAO
{
    public class StringerDAO : IStringerDAO
    {

        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public StringerDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
        }

        public string GetAllStringersForShop(string shopId)
        {
            string dataSet;
            try
            {
                // Call stored procedure
                _dataAccessLayer.AddParameters(0, "shopId", shopId);
                DataSet response =
                    _dataAccessLayer.ExecuteDataSet("GetAllStringersForShop", CommandType.StoredProcedure);
                dataSet = JsonConvert.SerializeObject(response.Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            // Return response from database
            return dataSet;
        }
    }
}