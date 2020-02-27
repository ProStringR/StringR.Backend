using System.Collections.Generic;
using StringR.Backend.DAO;
using StringR.Backend.DTO;

namespace StringR.Backend.DataController.Interface
{
    public interface IStringerDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        StringerDto GetStringerById(int stringerId);
        List<StringerDto> GetAllStringersForShop(int shopId);
        
        /*
         *
         *    POST
         * 
         */
        void PostStringerToTeam(int teamId, string firstName, string lastName, string phoneNumber, string email,
            int preferredRacketType);
    }
}