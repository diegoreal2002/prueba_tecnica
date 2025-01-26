using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyBankingApp.Application.Commands.Transactions;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;

namespace MyBankingApp.Tests.Handlers
{
    public class CreateTransactionCommandHandlerTests
    {
        [Fact]
        public async Task Withdrawal_Should_Decrease_Balance_When_Sufficient_Funds()
        {
            // Arrange
            var mockBankAccountRepository = new Mock<IBankAccountRepository>();
            var mockTransactionService = new Mock<ITransactionService>();

            var bankAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 500.00m
            };

            mockBankAccountRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(bankAccount);

            var handler = new CreateTransactionCommandHandler(mockTransactionService.Object, mockBankAccountRepository.Object);

            var command = new CreateTransactionCommand
            {
                BankAccountId = 1,
                Amount = 100.00m,
                TransactionType = "Withdrawal"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            Assert.Equal(400.00m, bankAccount.Balance);
            mockBankAccountRepository.Verify(repo => repo.UpdateAsync(bankAccount), Times.Once);
        }

        [Fact]
        public async Task Withdrawal_Should_Fail_When_Insufficient_Funds()
        {
            // Arrange
            var mockBankAccountRepository = new Mock<IBankAccountRepository>();
            var mockTransactionService = new Mock<ITransactionService>();

            var bankAccount = new BankAccount
            {
                BankAccountId = 1,
                Balance = 50.00m
            };

            mockBankAccountRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(bankAccount);

            var handler = new CreateTransactionCommandHandler(mockTransactionService.Object, mockBankAccountRepository.Object);

            var command = new CreateTransactionCommand
            {
                BankAccountId = 1,
                Amount = 100.00m,
                TransactionType = "Withdrawal"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            Assert.Equal(50.00m, bankAccount.Balance);
            mockBankAccountRepository.Verify(repo => repo.UpdateAsync(bankAccount), Times.Never);
        }
    }
}
