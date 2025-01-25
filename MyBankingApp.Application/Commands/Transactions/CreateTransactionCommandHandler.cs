using MediatR;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, bool>
    {
        private readonly ITransactionService _transactionService;

        public CreateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                BankAccountOriginId = request.BankAccountId,
                Amount = request.Amount,
                Type = request.TransactionType,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionService.ProcessTransactionAsync(transaction);
            return true;
        }
    }
}
