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
        var fromAccount = await _bankAccountRepository.GetByIdAsync(request.FromAccountId);
        var toAccount = await _bankAccountRepository.GetByIdAsync(request.ToAccountId);

        if (fromAccount == null || toAccount == null || fromAccount.Balance < request.Amount)
            return false;

        fromAccount.Balance -= request.Amount;
        toAccount.Balance += request.Amount;

        await _bankAccountRepository.UpdateAsync(fromAccount);
        await _bankAccountRepository.UpdateAsync(toAccount);

        await _transactionRepository.AddAsync(new Transaction
        {
            BankAccountOriginId = fromAccount.BankAccountId,
            Amount = -request.Amount,
            Type = "Transfer",
            TransactionDate = DateTime.UtcNow
        });

        await _transactionRepository.AddAsync(new Transaction
        {
            BankAccountDestinationId = toAccount.BankAccountId,
            Amount = request.Amount,
            Type = "Transfer",
            TransactionDate = DateTime.UtcNow
        });

        return true;
    }
}
