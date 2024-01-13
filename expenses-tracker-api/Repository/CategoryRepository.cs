using expenses_tracker_api.Data;
using expenses_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace expenses_tracker_api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;

        }

         
        public bool CategoriesExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();

        }

        public bool DeleteCategory(Category category)
        {
           _context.Remove(category);   
            return Save();  
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();  
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.Where(c => c.Id == id).FirstOrDefault();

            return category;
               
        }

        public bool Save()
        {
            var saved = _context.SaveChanges(); 
            return saved > 0 ? true : false;
        }
    }
}
