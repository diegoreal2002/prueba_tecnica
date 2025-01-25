namespace MyBankingApp.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int? BankAccountOriginId { get; set; }
        public int? BankAccountDestinationId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }

        public BankAccount BankAccountOrigin { get; set; }
        public BankAccount BankAccountDestination { get; set; }
    }
}
