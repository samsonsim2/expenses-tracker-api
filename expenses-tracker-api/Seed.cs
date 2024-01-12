using expenses_tracker_api.Data;
using expenses_tracker_api.Models;

namespace expenses_tracker_api
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;
        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            if (!_context.UserCategories.Any())
            {
                var userCategories = new List<UserCategory>()
                {
                    new UserCategory()
                    {
                        User = new User()
                        {
                            FirstName="Samson",
                            LastName ="Sim",
                            Email="Samsonsim2@gmail.com",
                            ImageUrl= "https://unsplash.com/photos/a-brick-wall-with-a-brick-wall-4l8G33tbRFY",
                            MainCurrency="SGD",

                        },
                        Category = new Category()
                        {
                            Name="Food",
                            Color="#ff5733",
                            IncomeExpense= new IncomeExpense()
                            {
                                Name="Income"
                            },
                            DefaultCategory= true,

                        }
                    },
 
                };
                _context.UserCategories.AddRange(userCategories);
                _context.SaveChanges();
            }
        }

    }
}
