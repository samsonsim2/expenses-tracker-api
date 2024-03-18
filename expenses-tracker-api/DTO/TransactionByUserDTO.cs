namespace expenses_tracker_api.DTO
{
    public class TransactionByUserDTO
    {

        public int? Id{ get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string CategoryColor { get; set; }
        public int CategoryIncomeExpenseId { get; set; }

    }
}
