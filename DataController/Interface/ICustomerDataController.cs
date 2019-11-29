namespace StringR.Backend.DataController.Interface
{
    public interface ICustomerDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        string GetAllCustomers();
        string GetCustomerById(int customerId);
        
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