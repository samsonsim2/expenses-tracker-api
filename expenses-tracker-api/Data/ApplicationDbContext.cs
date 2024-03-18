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
                AmazonUsername = "123",
                FirstName = "Admin",
                LastName = "User",
                Email = "AdminUser@gmail.com",
                ImageUrl = "https://unsplash.com/photos/a-brick-wall-with-a-brick-wall-4l8G33tbRFY",
                MainCurrency = "SGD",

            };
             
            modelBuilder.Entity<User>().HasData(user1);

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
            var category3 = new Category
            {
                Id =3,
                Name = "Transportation",
                Color = "#0080ff",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category4 = new Category
            {
                Id = 4,
                Name = "Groceries",
                Color = "#3b3b3b",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category5 = new Category
            {
                Id = 5,
                Name = "Housing",
                Color = "#f4d03f",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category6 = new Category
            {
                Id = 6,
                Name = "Clothing",
                Color = "#00ff7f",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category7 = new Category
            {
                Id = 7,
                Name = "Utilities",
                Color = "#ff1493",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category8 = new Category
            {
                Id = 8,
                Name = "Health",
                Color = "#ff8c00",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category9 = new Category
            {
                Id = 9,
                Name = "Education",
                Color = "#800000",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category10 = new Category
            {
                Id = 10,
                Name = "Insurance",
                Color = "#6a5acd",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category11 = new Category
            {
                Id = 11,
                Name = "Tax",
                Color = "#f08080",
                IncomeExpenseId = 1,
                DefaultCategory = true,

            };
            var category12 = new Category
            {
                Id = 12,
                Name = "Salary",
                Color = "#ffa07a",
                IncomeExpenseId = 2,
                DefaultCategory = true,

            };
            var category13 = new Category
            {
                Id = 13,
                Name = "Allowance",
                Color = "#8b0000",
                IncomeExpenseId = 2,
                DefaultCategory = true,

            };
            var category14 = new Category
            {
                Id = 14,
                Name = "Bonus",
                Color = "#00ced1",
                IncomeExpenseId = 2,
                DefaultCategory = true,

            };
            
            modelBuilder.Entity<Category>().HasData(category1, category2, category3, category4, category5, category6, category7, category8, category9, category10, category11, category12, category13,category14);

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
            var userCategory3 = new UserCategory
            {
                Id = 3,
                UserId = 1,
                CategoryId = 3,
            };
            var userCategory4 = new UserCategory
            {
                Id = 4,
                UserId = 1,
                CategoryId = 4,
            };
            var userCategory5 = new UserCategory
            {
                Id = 5,
                UserId = 1,
                CategoryId = 5,
            };
            var userCategory6 = new UserCategory
            {
                Id = 6,
                UserId = 1,
                CategoryId = 6,
            };
            var userCategory7 = new UserCategory
            {
                Id = 7,
                UserId = 1,
                CategoryId = 7,
            };
            var userCategory8 = new UserCategory
            {
                Id = 8,
                UserId = 1,
                CategoryId = 8,

            };
            var userCategory9 = new UserCategory
            {
                Id = 9,
                UserId = 1,
                CategoryId = 9,

            };
            var userCategory10 = new UserCategory
            {
                Id = 10,
                UserId = 1,
                CategoryId = 10,

            };
            var userCategory11 = new UserCategory
            {
                Id = 11,
                UserId = 1,
                CategoryId = 11,

            };
            var userCategory12 = new UserCategory
            {
                Id = 12,
                UserId = 1,
                CategoryId = 12,

            };
            var userCategory13 = new UserCategory
            {
                Id = 13,
                UserId = 1,
                CategoryId = 13,

            };
            var userCategory14 = new UserCategory
            {
                Id = 14,
                UserId = 1,
                CategoryId = 14,

            };
            modelBuilder.Entity<UserCategory>().HasData(userCategory1, userCategory2, userCategory3, userCategory4, userCategory5, userCategory6, userCategory7, userCategory8, userCategory9, userCategory10, userCategory11, userCategory12, userCategory13, userCategory14);


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
