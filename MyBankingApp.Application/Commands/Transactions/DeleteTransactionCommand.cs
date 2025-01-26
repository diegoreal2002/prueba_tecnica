using MediatR;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class DeleteTransactionCommand : IRequest<bool>
    {
        public int TransactionId { get; set; }
    }
}
