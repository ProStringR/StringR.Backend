using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace StringR.Backend.Models
{
    public class Person
    {
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;

        public Person(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
        }

        public string GetAllPersons()
        {
            string value;
            try
            {
                DataSet dataSet = _dataAccessLayer.ExecuteDataSet("getAll", CommandType.StoredProcedure);
                
                Console.WriteLine(JsonConvert.SerializeObject(dataSet.Tables[0]));
                var data = dataSet.Tables[0].Rows[0];
                value = data["lastName"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return value;
        }
    }
}