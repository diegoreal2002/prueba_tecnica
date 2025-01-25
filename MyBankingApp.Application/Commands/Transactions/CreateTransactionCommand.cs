using MediatR;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class CreateTransactionCommand : IRequest<bool>
    {
        public int BankAccountId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // Withdrawal, Deposit, Transfer
    }
}
