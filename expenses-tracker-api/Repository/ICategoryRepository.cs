using expenses_tracker_api.Models;

namespace expenses_tracker_api.Repository
{
    public interface ICategoryRepository
    {

        ICollection<Category> GetCategories();

        ICollection<Category> GetUserCategories(int id);

        Category GetCategory(int id);

        bool CategoriesExists(int id);  

        bool CreateCategory(Category category,int userId);

        bool UpdateCategory(Category category);

        bool DeleteCategory(Category category);

        bool Save();
    }
}
