using Microsoft.EntityFrameworkCore;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBankingApp.Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly BankingDbContext _context;

        public BankAccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> GetByIdAsync(int id)
        {
            return await _context.BankAccounts.FindAsync(id);
        }

        public async Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            return await _context.BankAccounts.ToListAsync();
        }

        public async Task AddAsync(BankAccount account)
        {
            await _context.BankAccounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BankAccount account)
        {
            _context.BankAccounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await GetByIdAsync(id);
            if (account != null)
            {
                _context.BankAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
