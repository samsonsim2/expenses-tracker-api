using expenses_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace expenses_tracker_api.Data
{
    public class ApplicationDbContext :DbContext
    {


        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                                   new User
                                   {
                                       Id = 1,
                                       firstName = "samson",
                                       lastName = "sim",
                                       email = "samsonsim@gmail.com",
                                                                  

                                   },
                                    new User
                                    {
                                        Id = 2,
                                        firstName = "test",
                                        lastName = "user",
                                        email = "testuser@gmail.com",


                                    }


                                   );
        }
    }
}
