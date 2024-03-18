using expenses_tracker_api.Models;

namespace expenses_tracker_api.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool DefaultCategory { get; set; } = false;

        public int IncomeExpenseId { get; set; }

        //public ICollection<int> UserCategoryUserId { get; set; }



    }
}
