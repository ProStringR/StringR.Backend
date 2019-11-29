namespace StringR.Backend.DataController.Interface
{
    public interface IShopDataController
    {
        
        /*
         *
         *    GET
         * 
         */
        string GetShopById(int shopId);
        
        /*
         *
         *    Validate
         * 
         */
        long ValidateShop(string userName, string password);
    }
}