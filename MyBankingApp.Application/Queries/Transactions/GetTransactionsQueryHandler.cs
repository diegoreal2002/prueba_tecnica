using MediatR;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;


namespace MyBankingApp.Application.Queries.Transactions
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetAllAsync();
        }
    }
}
