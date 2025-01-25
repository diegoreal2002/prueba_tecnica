using System.Threading.Tasks;
using MyBankingApp.Application.Interfaces; 
using MyBankingApp.Domain.Entities;

namespace MyBankingApp.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task ProcessTransactionAsync(Transaction transaction)
        {
            // Aquí puedes agregar validaciones o lógica específica según el tipo de transacción.
            await _transactionRepository.AddAsync(transaction);
        }
    }
}
