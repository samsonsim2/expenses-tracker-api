namespace expenses_tracker_api.Models
{
    public class Transaction
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public double Amount {  get; set; }
        public DateTime Date { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



        //1-m
        
        public int UserId { get; set; }  
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
