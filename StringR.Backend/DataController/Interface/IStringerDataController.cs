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
        
        /*
         *
         *    POST
         * 
         */
        void PostStringerToTeam(int teamId, string firstName, string lastName, string phoneNumber, string email,
            int preferredRacketType);
    }
}