using MediatR;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, bool>
    {
        private readonly ITransactionService _transactionService;
        private readonly IBankAccountRepository _bankAccountRepository;

        public CreateTransactionCommandHandler(ITransactionService transactionService, IBankAccountRepository bankAccountRepository)
        {
            _transactionService = transactionService;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            // Obtener la cuenta bancaria
            var bankAccount = await _bankAccountRepository.GetByIdAsync(request.BankAccountId);
            if (bankAccount == null)
                return false; // La cuenta no existe

            var typeT = "";

            // Validar transacción de depósito
            if (request.TransactionType == "Deposit")
            {
                if (request.Amount <= 0)
                    return false; // El monto debe ser mayor a 0

                // Actualizar el balance de la cuenta
                bankAccount.Balance += request.Amount;
                await _bankAccountRepository.UpdateAsync(bankAccount);

                typeT = "Deposit";
            }
            else if (request.TransactionType == "Withdrawal")
            {
                // Validar fondos suficientes
                if (request.Amount > bankAccount.Balance)
                    return false; // Fondos insuficientes

                // Actualizar el balance de la cuenta
                bankAccount.Balance -= request.Amount;
                await _bankAccountRepository.UpdateAsync(bankAccount);

                typeT = "Withdrawal";
            }

            // Crear y procesar la transacción
            var transaction = new Transaction
            {
                BankAccountOriginId = request.BankAccountId,
                Amount = request.Amount,
                Type = typeT, // Tipo de transacción
                TransactionDate = DateTime.UtcNow
            };

            await _transactionService.ProcessTransactionAsync(transaction);
            return true;
        }
    }
}
