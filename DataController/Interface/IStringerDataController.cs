using StringR.Backend.DAO;

namespace StringR.Backend.DataController.Interface
{
    public interface IStringerDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        string GetStringerById(int stringerId);
        string GetAllStringersForShop(int shopId);
    }
}