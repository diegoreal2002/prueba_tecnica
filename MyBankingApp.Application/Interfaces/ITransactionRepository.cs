namespace MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;
public interface ITransactionRepository
{
    Task<Transaction> GetByIdAsync(int id);
    Task<IEnumerable<Transaction>> GetAllAsync();
    Task AddAsync(Transaction transaction);
}
