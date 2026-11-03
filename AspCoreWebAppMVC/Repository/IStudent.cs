using AspCoreWebAppMVC.Models;

namespace AspCoreWebAppMVC.Repository
{
    public interface IStudent
    {
        List<UserData> GetUsers();
        UserData GetUserByID(int id);

    }
}
