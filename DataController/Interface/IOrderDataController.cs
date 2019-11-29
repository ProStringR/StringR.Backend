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
    }
}