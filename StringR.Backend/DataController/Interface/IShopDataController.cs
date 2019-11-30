using System;
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
        string GetShopById(int shopId);
        
        /*
         *
         *    POST
         * 
         */
        void PostShop(Shop shop);
        void PostTeamToShopWithMember(TeamToShopWithMember teamToShopWithMember);

        /*
         *
         *    Validate
         * 
         */
        long ValidateShop(string userName, string password);
    }
}