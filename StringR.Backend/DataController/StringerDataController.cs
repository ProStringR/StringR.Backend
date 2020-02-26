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

        public string GetAllStringersForShop(int shopId)
        {
            DataSet dataSet;

            try
            {
                dataSet = _stringerDAO.GetAllStringersForShop(shopId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return JsonConvert.SerializeObject(dataSet.Tables[0]);
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
                throw;
            }
        }
    }
}