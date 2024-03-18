using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;
using Microsoft.OpenApi.Any;

namespace expenses_tracker_api.Repository
{
    public interface ITransactionRepository
    {
        public ICollection<Transaction> GetTransactions();
        public Transaction GetTransaction(int id);

        public ICollection<TransactionByUserDTO> GetTransactionsByUser(int id,int month,int year,int pageSize,int pageNumber);

        
        public bool CreateTransaction(Transaction transaction);
        public Dictionary<String, Double> GetMonthlyExpenseSum(int id);
        public Dictionary<String, Double> GetMonthlyIncomeSum(int id);


        public int  CountTransactionPages(int id, int month, int year, int pageSize);
        public bool UpdateTransaction(Transaction transaction);
        public bool DeleteTransaction(Transaction transaction);

        public  bool TransactionExists(int id);
        bool Save();

    }
}
