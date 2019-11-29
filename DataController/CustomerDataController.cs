using System;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

namespace StringR.Backend.DataController
{
    public class CustomerDataController : ICustomerDataController
    {
        
        private CustomerDAO _customerDAO;
        
        public CustomerDataController(CustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }
        
        /*
         *
         *    GET
         * 
         */
        public string GetAllCustomers()
        {
            try
            {
                return JsonConvert.SerializeObject(_customerDAO.GetAllCustomers().Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string GetCustomerById(int customerId)
        {
            try
            {
                return JsonConvert.SerializeObject(_customerDAO.GetCustomerById(customerId).Tables[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void PostCustomer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string userId,
            string password,
            int preferredStringTypeId,
            double preferredTensionVertical,
            double preferredTensionHorizontal)
        {
            try
            {
                _customerDAO.PostCustomer(firstName, lastName, email, phoneNumber, userId, password, preferredStringTypeId, preferredTensionVertical, preferredTensionHorizontal);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}