using MyBankingApp.Domain.Entities;

public interface IBankAccountRepository
{
    Task<BankAccount> GetByIdAsync(int id);
    Task<IEnumerable<BankAccount>> GetAllAsync();
    Task AddAsync(BankAccount account);
    Task UpdateAsync(BankAccount account);
    Task DeleteAsync(int id);
}
