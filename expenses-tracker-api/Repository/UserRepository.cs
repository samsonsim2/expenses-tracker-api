using expenses_tracker_api.Data;
using expenses_tracker_api.Models;
using System.Linq;

namespace expenses_tracker_api.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
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
                

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context.Users.Where(u => u.AmazonUsername == username).FirstOrDefault();
            return user;
        }

        public User FindOrCreateUser(User user)
        {
           //check if user exist by user name

            if (UserExists(user.AmazonUsername))
            {
                user = GetUserByUsername(user.AmazonUsername);
                return user;
            }

            else
            {
                User newUser = new User
                {
                    AmazonUsername = user.AmazonUsername,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.FirstName,
                    
                };
                _context.Users.Add(newUser);
                Save();
                return newUser;
                
            }
        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.AmazonUsername == username);
        }
    }
}
