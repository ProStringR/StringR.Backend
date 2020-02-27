using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.DTO;

namespace StringR.Backend.DataController
{
    public class StringerDataController : IStringerDataController
    {

        private StringerDAO _stringerDAO;
        
        public StringerDataController(StringerDAO stringerDAO)
        {
            _stringerDAO = stringerDAO;
        }
        
        /*
         *
         *    GET
         * 
         */

        public StringerDto GetStringerById(int stringerId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_stringerDAO.GetStringerById(stringerId).Tables[0]);
                List<StringerDto> stringerDtos = JsonConvert.DeserializeObject<List<StringerDto>>(json);

                return stringerDtos.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public List<StringerDto> GetAllStringersForShop(int shopId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_stringerDAO.GetAllStringersForShop(shopId).Tables[0]);
                List<StringerDto> stringerDtos = JsonConvert.DeserializeObject<List<StringerDto>>(json);

                return stringerDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void PostStringerToTeam(int teamId, string firstName, string lastName, string phoneNumber, string email,
            int preferredRacketType)
        {
            try
            {
                _stringerDAO.PostStringerToTeam(teamId, firstName, lastName, phoneNumber, email, preferredRacketType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}