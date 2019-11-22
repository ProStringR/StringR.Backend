using System;
using StringR.Backend.DataController.Interface;
using StringR.Backend.Models;

namespace StringR.Backend.DataController
{
    public class StringerDataController
    {

        private IStringerDAO _stringerDAO;
        
        public StringerDataController(IStringerDAO stringerDAO)
        {
            _stringerDAO = stringerDAO;
        }

        public string GetAllStringersForShop(string shopId)
        {
            // Return Json string
            return _stringerDAO.GetAllStringersForShop(shopId);;
        }
    }
}