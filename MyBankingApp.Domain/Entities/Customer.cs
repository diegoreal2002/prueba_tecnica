namespace MyBankingApp.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }

        //public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
