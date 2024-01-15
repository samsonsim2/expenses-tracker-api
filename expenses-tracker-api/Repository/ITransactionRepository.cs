using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;

namespace expenses_tracker_api.Repository
{
    public interface ITransactionRepository
    {
        public ICollection<Transaction> GetTransactions();
        public Transaction GetTransaction(int id);

        public ICollection<TransactionByUserDTO> GetTransactionsByUser(int id);

        
        public bool CreateTransaction(Transaction transaction);

        public bool UpdateTransaction(Transaction transaction);
        public bool DeleteTransaction(Transaction transaction);

        public  bool TransactionExists(int id);
        bool Save();

    }
}
