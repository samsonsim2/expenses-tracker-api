using expenses_tracker_api.Models;
 

namespace expenses_tracker_api.Repository
{
    public interface IUserRepository
    {

        ICollection<User> GetUsers();

        User GetUser(int id);

        User GetUserByUsername(string username);

        User FindOrCreateUser (User user);

        bool UserExists(string username);




    }
}
