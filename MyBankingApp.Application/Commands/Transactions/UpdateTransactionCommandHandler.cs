using MediatR;
using MyBankingApp.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, bool>
    {
        private readonly ITransactionRepository _transactionRepository;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.TransactionId);
            if (transaction == null)
                return false;

            // Actualizar solo los campos permitidos
            transaction.Description = request.Description;

            await _transactionRepository.UpdateAsync(transaction);
            return true;
        }
    }
}
