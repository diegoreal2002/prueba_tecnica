using MediatR;
using MyBankingApp.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, bool>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public DeleteTransactionCommandHandler(
            ITransactionRepository transactionRepository,
            IBankAccountRepository bankAccountRepository)
        {
            _transactionRepository = transactionRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.TransactionId);
            if (transaction == null)
                return false;

          

            // Eliminar la transacción
            await _transactionRepository.DeleteAsync(transaction.TransactionId);
            return true;
        }
    }
}
