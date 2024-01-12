namespace expenses_tracker_api.Models
{
    public class Transaction
    {
        public int Id { get; set; }       
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //1-m relationship
        public int UserId { get; set; }  
        public User User { get; set; } = null!;
    }
}
