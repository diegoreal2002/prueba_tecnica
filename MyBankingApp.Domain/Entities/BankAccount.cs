namespace MyBankingApp.Domain.Entities
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Transaction> TransaccionesOrigen { get; set; }
        public ICollection<Transaction> TransaccionesDestino { get; set; }
    }
}
