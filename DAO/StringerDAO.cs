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
        
        /*
         *
         *    GET
         * 
         */

        public DataSet GetStringerById(int stringerId)
        {
            try
            {
                return _dataController.GetAllDataFromId(stringerId, "GetStringerById");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
        }
        
        /*
         *
         *    POST
         * 
         */
        public void PostStringerToTeam(int teamId, string firstName, string lastName, string phoneNumber, string email,
            int preferredRacketType)
        {
            
            _dataAccessLayer.BeginTransaction();

            try
            {
                _dataAccessLayer.CreateParameters(6);
                _dataAccessLayer.AddParameters(0, "teamId", teamId);
                _dataAccessLayer.AddParameters(1, "firstName", firstName);
                _dataAccessLayer.AddParameters(2, "lastName", lastName);
                _dataAccessLayer.AddParameters(3, "phoneNumber", phoneNumber);
                _dataAccessLayer.AddParameters(4, "email", email);
                _dataAccessLayer.AddParameters(5, "preferredRacketType", preferredRacketType);

                _dataAccessLayer.ExecuteScalar("AddStringerToTeam", CommandType.StoredProcedure);
                
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