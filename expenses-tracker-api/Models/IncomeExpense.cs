namespace expenses_tracker_api.Models
{
    public class IncomeExpense
    {

        public int Id { get; set; }
        public string Name { get; set; }        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}

        // 1-m relationship 
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
