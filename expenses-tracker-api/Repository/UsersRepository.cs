using expenses_tracker_api.Data;
using expenses_tracker_api.Models;
using System.Linq;

namespace expenses_tracker_api.Repository
{
    public class UsersRepository : IUsersRepository
    {

        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public User GetUser(int id)
        {
            var user = _context.Users.Single(u => u.Id == id);
            return user;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
