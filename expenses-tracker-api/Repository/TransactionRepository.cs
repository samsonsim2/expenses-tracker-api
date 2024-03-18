using expenses_tracker_api.Data;
using expenses_tracker_api.DTO;
using expenses_tracker_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System;
using System.Globalization;

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

        public Dictionary<String,Double>  GetMonthlyExpenseSum(int userId)
        {
            var monthlyExpenseSum = _context.Transactions.Where(t => t.UserId == userId && t.Category.IncomeExpenseId ==1)
            .GroupBy(e => new { e.Date.Year, e.Date.Month })
          
            .Select(g => new
            {
                Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)} {g.Key.Year}",
                TotalAmount = g.Sum(e => e.Amount)
            })
            .ToDictionary(x => x.Month, x => x.TotalAmount);
            return monthlyExpenseSum;
        }

        public Dictionary<String, Double> GetMonthlyIncomeSum(int userId)
        {
            var monthlyExpenseSum = _context.Transactions.Where(t => t.UserId == userId && t.Category.IncomeExpenseId == 2)
            .GroupBy(e => new { e.Date.Year, e.Date.Month })
            .Select(g => new
            {
                Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)} {g.Key.Year}",
                TotalAmount = g.Sum(e => e.Amount)
            })
            .ToDictionary(x => x.Month, x => x.TotalAmount);
            return monthlyExpenseSum;
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

        public ICollection<TransactionByUserDTO> GetTransactionsByUser(int id,int month,int year,int pageSize, int pageNumber)
        {

            // Calculate how many records to skip based on the page number and page size
            int recordsToSkip = (pageNumber - 1) * pageSize;
                    


            var transactions = _context.Transactions.Where(t => t.UserId == id && t.Date.Month == month && t.Date.Year== year).Select(t => new TransactionByUserDTO
            {
                Id = t.Id,
                Amount = t.Amount,
                Name = t.Name,
                Date = t.Date,
                CategoryId = t.Category.Id,
                CategoryName = t.Category.Name,
                CategoryColor = t.Category.Color,
               CategoryIncomeExpenseId = t.Category.IncomeExpenseId

            }) .Skip(recordsToSkip)
                .Take(pageSize)
                .ToList();

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

        public int CountTransactionPages(int id, int month, int year, int pageSize)
        { 
            // Calculate the total number of records
            int totalRecords = _context.Transactions.Where(t => t.UserId == id && t.Date.Month == month && t.Date.Year == year).Count();

            // Calculate the total number of pages
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            return totalPages;
        }
    }
}
