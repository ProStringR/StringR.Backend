using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;
using StringR.Backend.DTO;

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
        public List<CustomerDTO> GetAllCustomers()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_customerDAO.GetAllCustomers().Tables[0]);
                return JsonConvert.DeserializeObject<List<CustomerDTO>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public CustomerDTO GetCustomerById(int customerId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_customerDAO.GetCustomerById(customerId).Tables[0]);
                List<CustomerDTO> customerDtos = JsonConvert.DeserializeObject<List<CustomerDTO>>(json);
                
                // No null check because error is thrown
                // in case the user does not exist
                return customerDtos[0];
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