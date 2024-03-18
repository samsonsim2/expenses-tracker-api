using expenses_tracker_api.Models;

namespace expenses_tracker_api.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }




        //1-m relationship       
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        //public Category Category { get; set; }  
        public string CategoryName { get; set; }
        public string CategoryIncomeExpenseId  { get; set; }

        public string CategoryColor { get; set; }
    }
}
