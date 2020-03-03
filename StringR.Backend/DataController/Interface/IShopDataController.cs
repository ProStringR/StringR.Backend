using System;
using StringR.Backend.DTO;
using StringR.Backend.Models;

namespace StringR.Backend.DataController.Interface
{
    public interface IShopDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        ShopDto GetShopById(int shopId);
        
        /*
         *
         *    POST
         * 
         */
        void PostShop(Shop shop);

        /*
         *
         *    Validate
         * 
         */
        (int shopId, string password, int teamId) ValidateShop(string userName);
    }
}