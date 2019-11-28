using StringR.Backend.DAO;

namespace StringR.Backend.DataController.Interface
{
    public interface IStringerDataController
    {
        string GetStringerById(int stringerId);
        string GetAllStringersForShop(int shopId);
    }
}