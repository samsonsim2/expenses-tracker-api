using expenses_tracker_api.Models;
 

namespace expenses_tracker_api.Repository
{
    public interface IUsersRepository
    {

        ICollection<User> GetUsers();

        User GetUser(int id);
    }
}
