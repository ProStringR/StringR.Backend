namespace StringR.Backend.DataController.Interface
{
    public interface ICustomerDataController
    {
        string GetAllCustomers();
        string GetCustomerById(int customerId);
    }
}