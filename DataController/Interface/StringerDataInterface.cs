using StringR.Backend.DAO;

namespace StringR.Backend.DataController.Interface
{
    public interface StringerDataInterface
    {
        string GetAllStringersForShop(int shopId);
    }
}