namespace expenses_tracker_api.Models
{
    public class Category
    {

        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Color{ get; set; }
        public Boolean DefaultCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // 1-m relationship 
        public int IncomeExpenseId { get; set; } 
        public IncomeExpense IncomeExpense { get; set; } = null!;

        // m-m relationship 
        public List<UserCategory> UserCategory { get; set; }

    }
}
