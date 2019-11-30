using StringR.Backend.Models;

namespace StringR.Backend.DataController.Interface
{
    public interface IOrderDataController
    {
        
        /*
         *         
         *    GET
         * 
         */
        string GetOrderById(int orderId);
        string GetAllOrdersForShop(int shopId);
        string GetAllOrdersForShopOnStatus(int shopId, int orderStatus);
        
        /*
         *
         *    POST
         * 
         */
        void PostOrder(Order order);
        
        /*
         *
         *    PUT
         * 
         */
        void PutOrder(int orderId, long transactionDate, bool paidStatus, int orderStatus);
    }
}