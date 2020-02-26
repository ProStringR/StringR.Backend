using System.Collections.Generic;
using StringR.Backend.DTO;
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
        OrderDto GetOrderById(int orderId);
        List<OrderDto> GetAllOrdersForShop(int shopId);
        List<OrderDto> GetAllOrdersForShopOnStatus(int shopId, int orderStatus);
        
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