
using StringR.Backend.DTO;

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
        string GetAllStringsForShop(int shopId);
        
        /*
         *
         *    POST
         * 
         */

        /*
         *
         *    PUT
         * 
         */
        void PutRacketStringToStorage(int stringId, double price, long transactionDate, int lengthAdded);
    }
}