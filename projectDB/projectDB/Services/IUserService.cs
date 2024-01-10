using projectDB.Entities;

namespace projectDB.Services
{
    public interface IUserService
    {
        //methods
        User addUser(User user);
        void removeUser(User user);

        //this method will be accessed by the admin
        List<User> getAllUsers();

        User UpdateUser(User user);

        User GetUser(int id);


        User ValidateUser(string username, string password);



    }
}
