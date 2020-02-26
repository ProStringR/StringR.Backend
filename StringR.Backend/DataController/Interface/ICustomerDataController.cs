using System.Collections.Generic;
using StringR.Backend.DTO;

namespace StringR.Backend.DataController.Interface
{
    public interface ICustomerDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        List<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int customerId);
        
        /*
         *
         *    POST
         * 
         */
        void PostCustomer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string userId,
            string password,
            int preferredStringTypeId,
            double preferredTensionVertical,
            double preferredTensionHorizontal);
    }
}