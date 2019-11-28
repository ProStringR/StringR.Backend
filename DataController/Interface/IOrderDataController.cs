namespace StringR.Backend.DataController.Interface
{
    public interface IOrderDataController
    {
        string GetOrderById(int orderId);
        string GetAllOrdersForShop(int shopId);
        string GetAllOrdersForShopOnStatus(int shopId, int orderStatus);
    }
}