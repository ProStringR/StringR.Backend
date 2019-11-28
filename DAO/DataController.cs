using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;

namespace StringR.Backend.DAO
{
    public class DataController
    {
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public DataController(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
        }

        public DataSet GetAllDataFromId(int id, string storedProcedure) 
        {          
            try
            {
                // Call stored procedure
                _dataAccessLayer.CreateParameters(1);
                _dataAccessLayer.AddParameters(0, "id", id);
                DataSet response =
                    _dataAccessLayer.ExecuteDataSet(storedProcedure, CommandType.StoredProcedure);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
                throw;
            }
        }

    }
}