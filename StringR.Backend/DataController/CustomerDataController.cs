using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<CustomerDto> GetAllCustomers()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_customerDAO.GetAllCustomers().Tables[0]);
                return JsonConvert.DeserializeObject<List<CustomerDto>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_customerDAO.GetCustomerById(customerId).Tables[0]);
                List<CustomerDto> customerDtos = JsonConvert.DeserializeObject<List<CustomerDto>>(json);

                return customerDtos.FirstOrDefault();
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