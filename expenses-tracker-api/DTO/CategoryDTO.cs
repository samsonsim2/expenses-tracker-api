namespace expenses_tracker_api.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public int IncomeExpenseId { get; set; }
    }
}
