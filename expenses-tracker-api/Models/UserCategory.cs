namespace expenses_tracker_api.Models
{
    public class UserCategory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!; 
        public User User { get; set; }    
         
    }
}
