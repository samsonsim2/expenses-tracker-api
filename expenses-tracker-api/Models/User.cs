namespace expenses_tracker_api.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string? AmazonUsername { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

        public string? MainCurrency { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //1-m 
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();


        // m-m relationship 
        public List<UserCategory> UserCategory { get; set; }
    }
}
