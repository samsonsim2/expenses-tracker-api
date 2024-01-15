using expenses_tracker_api.Data;
using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace expenses_tracker_api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool CreateTransaction(Transaction transaction)
        {
            _context.Add(transaction);
            return Save();
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            _context.Update(transaction);
            return Save();
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            _context.Remove(transaction);
            return Save();
        }

        public Transaction GetTransaction(int id)
        {
            var transaction = _context.Transactions.Where(t => t.Id == id).FirstOrDefault();
            return transaction;
        }

        public ICollection<TransactionByUserDTO> GetTransactionsByUser(int id)
        {

             
            var transactions = _context.Transactions.Where(t => t.UserId == id).Select(t => new TransactionByUserDTO
            {
                Id = t.Id,
                Amount = t.Amount,
                Name = t.Name,
                Date = t.Date,
                CategoryId = t.Category.Id,
                CategoryName = t.Category.Name,
                CategoryColor = t.Category.Color

            }).ToList();

            return transactions;
        }

        public ICollection<Transaction> GetTransactions()
        {
            return _context.Transactions.Include(t=>t.Category).ToList();
        }
    
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransactionExists(int id)
        {
            return _context.Transactions.Any(t => t.Id == id);
        }

       

         
    }
}
