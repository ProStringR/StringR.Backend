
namespace StringR.Backend.DataController.Interface
{
    public interface IRacketStringDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        string GetStringById(int racketStringId);
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