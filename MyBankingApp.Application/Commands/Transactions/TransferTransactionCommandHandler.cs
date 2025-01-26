using MediatR;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;

public class TransferTransactionCommandHandler : IRequestHandler<TransferTransactionCommand, bool>
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransferTransactionCommandHandler(IBankAccountRepository bankAccountRepository, ITransactionRepository transactionRepository)
    {
        _bankAccountRepository = bankAccountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task<bool> Handle(TransferTransactionCommand request, CancellationToken cancellationToken)
    {
        // Obtener las cuentas bancarias
        var fromAccount = await _bankAccountRepository.GetByIdAsync(request.FromAccountId);
        var toAccount = await _bankAccountRepository.GetByIdAsync(request.ToAccountId);

        // Validar que las cuentas existan
        if (fromAccount == null || toAccount == null)
            return false;

        // Validar fondos suficientes en la cuenta de origen
        if (fromAccount.Balance < request.Amount)
            return false;

        // Actualizar balances
        fromAccount.Balance -= request.Amount;
        toAccount.Balance += request.Amount;

        await _bankAccountRepository.UpdateAsync(fromAccount);
        await _bankAccountRepository.UpdateAsync(toAccount);

        // Registrar la transacción
        var transfer = new Transaction
        {
            BankAccountOriginId = fromAccount.BankAccountId,
            BankAccountDestinationId = toAccount.BankAccountId,
            Amount = -request.Amount,
            Type = "Transfer",
            TransactionDate = DateTime.UtcNow
        };


        await _transactionRepository.AddAsync(transfer);

        return true;
    }
}
