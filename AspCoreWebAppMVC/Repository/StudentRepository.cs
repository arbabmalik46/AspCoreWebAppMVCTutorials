using AspCoreWebAppMVC.Models;

namespace AspCoreWebAppMVC.Repository
{
    public class StudentRepository : IStudent
    {
        public UserData GetUserByID(int id)
        {
            return DataSource().Where(x=>x.Id == id).FirstOrDefault();
        }

        public List<UserData> GetUsers()
        {
            return DataSource();
        }
        private List<UserData> DataSource()
        {
            var userData = new List<UserData>
            {
                new UserData { Id = 1,UserName = "John Doe", UserAge = 25, UserEmail = "john.doe@example.com", Password = "password123" },
                new UserData { Id = 2,UserName = "Jane Smith", UserAge = 30, UserEmail = "jane.smith@example.com", Password = "password456" },
                new UserData { Id = 3,UserName = "Alice Johnson", UserAge = 22, UserEmail = "alice.johnson@example.com", Password = "password789" },
                new UserData { Id = 4,UserName = "Bob Brown", UserAge = 28, UserEmail = "bob.brown@example.com", Password = "password012" },
                new UserData { Id = 5,UserName = "Charlie Davis", UserAge = 35, UserEmail = "charlie.davis@example.com", Password = "password345" }
            };
            return userData;
        }
    }
}
