using System;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.Models;

namespace StringR.Backend.DataController
{
    public class ShopDataController : IShopDataController
    {
        private ShopDAO _shopDAO;
        
        public ShopDataController(ShopDAO shopDAO)
        {
            _shopDAO = shopDAO;
        }
        
        /*
         *
         *    GET
         * 
         */

        public string GetShopById(int shopId)
        {
            try
            {
                return JsonConvert.SerializeObject(GetShopAsJObject(_shopDAO.GetShopById(shopId).Tables[0].Rows[0]));
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
            try
            {
                _shopDAO.PostShop(shop);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void PostTeamToShopWithMember(TeamToShopWithMember teamToShopWithMember)
        {
            try
            {
                _shopDAO.PostTeamToShopWithMember(teamToShopWithMember);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /*
         *
         *    Validate
         * 
         */
        public long ValidateShop(string userName, string password)
        {
            var dataSet = _shopDAO.ValidateShop(userName, password);

            return (long) dataSet.Tables[0].Rows[0]["response"];
        }

        private JObject GetShopAsJObject(DataRow row)
        {

            var jObject = new JObject();
            
            jObject.Add("id", (int) row["shopId"]);
            jObject.Add("teamId", (int) row["teamId"]);
            jObject.Add("phoneNumber", row["phoneNumber"].ToString());
            jObject.Add("company", row["company"].ToString());
            
            // address construction
            var address = new JObject();
            address.Add("zipCode", row["zipCode"].ToString());
            address.Add("city", row["city"].ToString());
            address.Add("country", row["country"].ToString());
            address.Add("longitude", row["longitude"].ToString());
            address.Add("latitude", row["latitude"].ToString());
            address.Add("street", row["street"].ToString());
            address.Add("addressNumber", row["addressNumber"].ToString());
            
            var addressProperty = new JProperty("address", address);
            
            jObject.Add(addressProperty);

            return jObject;
        }
    }
}