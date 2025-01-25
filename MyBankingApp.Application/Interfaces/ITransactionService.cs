using MyBankingApp.Domain.Entities;
using System.Threading.Tasks;
namespace MyBankingApp.Application.Interfaces
{
    public interface ITransactionService
    {
        Task ProcessTransactionAsync(Transaction transaction);
    }
}
