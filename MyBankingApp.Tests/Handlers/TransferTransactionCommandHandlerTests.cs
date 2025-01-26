using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyBankingApp.Application.Commands.Transactions;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;

namespace MyBankingApp.Tests.Handlers
{
    public class TransferTransactionCommandHandlerTests
    {
        [Fact]
        public async Task Transfer_Should_Update_Balances_When_Valid()
        {
            // Arrange
            var mockBankAccountRepository = new Mock<IBankAccountRepository>();
            var mockTransactionRepository = new Mock<ITransactionRepository>();

            var fromAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 500.00m
            };

            var toAccount = new BankAccount
            {
                BankAccountId = 2,
                Balance = 300.00m
            };

            mockBankAccountRepository
                .Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(fromAccount);

            mockBankAccountRepository
                .Setup(repo => repo.GetByIdAsync(2))
                .ReturnsAsync(toAccount);

            var handler = new TransferTransactionCommandHandler(mockBankAccountRepository.Object, mockTransactionRepository.Object);

            var command = new TransferTransactionCommand
            {
                FromAccountId = 1,
                ToAccountId = 2,
                Amount = 200.00m
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            Assert.Equal(300.00m, fromAccount.Balance);
            Assert.Equal(500.00m, toAccount.Balance);
            mockBankAccountRepository.Verify(repo => repo.UpdateAsync(fromAccount), Times.Once);
            mockBankAccountRepository.Verify(repo => repo.UpdateAsync(toAccount), Times.Once);
        }
    }
}
