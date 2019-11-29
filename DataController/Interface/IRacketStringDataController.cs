
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
    }
}