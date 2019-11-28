
namespace StringR.Backend.DataController.Interface
{
    public interface IRacketStringDataController
    {
        string GetStringById(int racketStringId);
        string GetAllStringsForShop(int shopId);
    }
}