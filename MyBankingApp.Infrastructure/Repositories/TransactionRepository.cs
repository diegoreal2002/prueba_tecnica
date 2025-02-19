﻿using Microsoft.EntityFrameworkCore;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBankingApp.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankingDbContext _context;

        public TransactionRepository(BankingDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transaction = await GetByIdAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

    }
}
