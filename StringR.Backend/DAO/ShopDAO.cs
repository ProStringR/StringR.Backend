using System;
using System.Data;
using Database.DatabaseConnector;
using Microsoft.Extensions.Configuration;
using StringR.Backend.Controllers.v1;
using StringR.Backend.Models;

namespace StringR.Backend.DAO
{
    public class ShopDAO
    {
        private DataController _dataController;
        private DataAccessLayer.DataAccessLayerBaseClass _dataAccessLayer;
        
        public ShopDAO(IConfiguration configuration)
        {
            _dataAccessLayer = DataAccessLayer.DataAccessLayerFactory.GetDataAccessLayer(configuration);
            _dataController = new DataController(configuration);
        }
        
        /*
         *
         *    GET
         * 
         */

        public DataSet GetShopById(int shopId)
        {
            try
            {
                return _dataController.GetAllDataFromId(shopId, "GetShopById");
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
        public void PostShop(Shop shop)
        {
            _dataAccessLayer.BeginTransaction();
            try
            {
                _dataAccessLayer.CreateParameters(11);
                _dataAccessLayer.AddParameters(0, "shopName", shop.ShopName);
                _dataAccessLayer.AddParameters(1, "zipCode", shop.ZipCode);
                _dataAccessLayer.AddParameters(2, "city", shop.City);
                _dataAccessLayer.AddParameters(3, "country", shop.Country);
                _dataAccessLayer.AddParameters(4, "longitude", shop.Longitude);
                _dataAccessLayer.AddParameters(5, "latitude", shop.Latitude);
                _dataAccessLayer.AddParameters(6, "street", shop.Street);
                _dataAccessLayer.AddParameters(7, "addressNumber", shop.AddressNumber);
                _dataAccessLayer.AddParameters(8, "phoneNumber", shop.PhoneNumber);
                _dataAccessLayer.AddParameters(9, "userId", shop.UserId);
                _dataAccessLayer.AddParameters(10, "password", AuthenticationController.HashingPassword(shop.Password));

                _dataAccessLayer.ExecuteScalar("CreateShop", CommandType.StoredProcedure);
                
                _dataAccessLayer.CommitTransaction();
            }
            catch (Exception e)
            {
                _dataAccessLayer.RollbackTransaction();
                throw;
            }
        }

        public void PostTeamToShopWithMember(TeamToShopWithMember teamToShopWithMember)
        {
            _dataAccessLayer.BeginTransaction();
            try
            {
                _dataAccessLayer.CreateParameters(6);
                _dataAccessLayer.AddParameters(0, "firstName", teamToShopWithMember.FirstName);
                _dataAccessLayer.AddParameters(1, "lastName", teamToShopWithMember.LastName);
                _dataAccessLayer.AddParameters(2, "phoneNumber", teamToShopWithMember.PhoneNumber);
                _dataAccessLayer.AddParameters(3, "email", teamToShopWithMember.Email);
                _dataAccessLayer.AddParameters(4, "preferredRacketType", teamToShopWithMember.PreferredRacketType);
                _dataAccessLayer.AddParameters(5, "shopId", teamToShopWithMember.ShopId);

                _dataAccessLayer.ExecuteScalar("CreateShop", CommandType.StoredProcedure);
                
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
         *    Validate
         * 
         */
        public DataSet ValidateShop(string userName)
        {
            try
            {
                _dataAccessLayer.CreateParameters(1);
                _dataAccessLayer.AddParameters(0, "userId", userName);

                return _dataAccessLayer.ExecuteDataSet("AuthenticateShop", CommandType.StoredProcedure);;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
                throw;
            }
        }
    }
}