
using System.Collections.Generic;
using StringR.Backend.DTO;
using StringR.Backend.Models;

namespace StringR.Backend.DataController.Interface
{
    public interface IRacketStringDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        RacketStringDto GetStringById(int racketStringId);
        List<RacketStringDto> GetAllStringsForShop(int shopId);
        
        /*
         *
         *    POST
         * 
         */
        void PostRacketStringToStorage(RacketString racketString);

        /*
         *
         *    PUT
         * 
         */
        void PutRacketStringToStorage(int stringId, double price, long transactionDate, int lengthAdded);
        
        /*
        *
        *    Delete
        * 
        */
        void DeleteRacketString(int stringId);
    }
}