using MediatR;
using MyBankingApp.Domain.Entities;

namespace MyBankingApp.Application.Queries.Transactions
{
    public class GetTransactionsQuery : IRequest<IEnumerable<Transaction>>
    {
        public int BankAccountId { get; set; }
    }
}
