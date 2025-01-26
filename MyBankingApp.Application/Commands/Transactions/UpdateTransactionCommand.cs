using MediatR;

namespace MyBankingApp.Application.Commands.Transactions
{
    public class UpdateTransactionCommand : IRequest<bool>
    {
        public int TransactionId { get; set; }
        public string? Description { get; set; }
    }
}