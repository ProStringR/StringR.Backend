using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Models;

namespace StringR.Backend.DAO
{
    public class RacketDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public RacketDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }
        
        /*
         *
         *    GET
         * 
         */
        
        /*
         *
         *    POST
         * 
         */
        public void PostRacket(Racket racket)
        {
            _dataAccessLayer.BeginTransaction();

            try
            {
                _dataAccessLayer.CreateParameters(6);
                _dataAccessLayer.AddParameters(0, "brand", racket.Brand);
                _dataAccessLayer.AddParameters(1, "model", racket.Model);
                _dataAccessLayer.AddParameters(2, "weight", racket.Weight);
                _dataAccessLayer.AddParameters(3, "stringsMain", racket.StringsMain);
                _dataAccessLayer.AddParameters(4, "stringsCross", racket.StringsCross);
                _dataAccessLayer.AddParameters(5, "gripSize", racket.gripSize);

                _dataAccessLayer.ExecuteScalar("CreateRacket", CommandType.StoredProcedure);

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
        
        /*
         *
         *    DELETE
         * 
         */
    }
}