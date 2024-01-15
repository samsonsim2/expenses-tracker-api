using expenses_tracker_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace expenses_tracker_api.Data
{
    public class ApplicationDbContext :DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<IncomeExpense> IncomeExpenses { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IncomeExpense>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<IncomeExpense>()
               .Property(b => b.UpdatedAt)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Category>()
               .Property(b => b.UpdatedAt)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>()
               .Property(b => b.UpdatedAt)
               .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>()
               .Property(b => b.MainCurrency)
               .HasDefaultValue("SGD");

            modelBuilder.Entity<Transaction>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Transaction>()
               .Property(b => b.UpdatedAt)
               .HasDefaultValueSql("getdate()");

             

            var user1 = new User
            {
                Id = 1,
                FirstName = "Samson",
                LastName = "Sim",
                Email = "Samsonsim2@gmail.com",
                ImageUrl = "https://unsplash.com/photos/a-brick-wall-with-a-brick-wall-4l8G33tbRFY",
                MainCurrency = "SGD",

            };
            var user2 = new User
            {
                Id = 2,
                FirstName = "Sam",
                LastName = "Tan",
                Email = "SamTan2@gmail.com",
                ImageUrl = "https://unsplash.com/photos/a-brick-wall-with-a-brick-wall-4l8G33tbRFY",
                MainCurrency = "SGD",

            };
            modelBuilder.Entity<User>().HasData(user1, user2);

            var incomeExpense1 = new IncomeExpense()
            {
                Id = 1,
                Name = "Expense"
            };

            var incomeExpense2 = new IncomeExpense()
            {
                Id = 2,
                Name = "Income"
            };

            modelBuilder.Entity<IncomeExpense>().HasData(incomeExpense1, incomeExpense2);


            var category1 = new Category
            {
                Id = 1,
                Name = "Food",
                Color = "#ff5733",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category2 = new Category
            {
                Id = 2,
                Name = "Entertainment",
                Color = "#d500f9",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };

            modelBuilder.Entity<Category>().HasData(category1, category2);

            var userCategory1 = new UserCategory
            {
                Id = 1,
                UserId = 1,
                CategoryId = 1,


            };
            var userCategory2 = new UserCategory
            {
                Id = 2,
                UserId = 1,
                CategoryId = 2,
            };
            modelBuilder.Entity<UserCategory>().HasData(userCategory1, userCategory2);


            var transaction1 = new Transaction
            {
                Id = 1,
                UserId = 1,
                CategoryId = 1,
                Name = "starbucks",
                Amount = 7.5,
                Date = new DateTime()
            };

            var transaction2 = new Transaction
            {
                Id = 2,
                UserId = 1,
                CategoryId =2,
                Name = "McDonalds",
                Amount = 6.3,
                Date = new DateTime()
            };
            modelBuilder.Entity<Transaction>().HasData(transaction1, transaction2);


            base.OnModelCreating(modelBuilder);

        }
    }
}
