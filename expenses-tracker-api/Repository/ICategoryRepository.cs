using expenses_tracker_api.Models;

namespace expenses_tracker_api.Repository
{
    public interface ICategoryRepository
    {

        ICollection<Category> GetCategories();

        Category GetCategory(int id);

        bool CategoriesExists(int id);  

        bool CreateCategory(Category category);

        bool UpdateCategory(Category category);

        bool DeleteCategory(Category category);

        bool Save();
    }
}
