using Microsoft.EntityFrameworkCore;
using MyBankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
public class BankingDbContext : DbContext
{
    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración para BankAccount.Balance
        modelBuilder.Entity<BankAccount>()
            .Property(b => b.Balance)
            .HasColumnType("decimal(18,2)");

        // Configuración para Transaction.Amount
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasColumnType("decimal(18,2)");

        // Relaciones previamente configuradas
       /* modelBuilder.Entity<Transaction>()
            .HasOne(t => t.BankAccountOrigin)
            .WithMany(b => b.TransaccionesOrigen)
            .HasForeignKey(t => t.BankAccountOriginId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.BankAccountDestination)
            .WithMany(b => b.TransaccionesDestino)
            .HasForeignKey(t => t.BankAccountDestinationId)
            .OnDelete(DeleteBehavior.Restrict);
       
        modelBuilder.Entity<Customer>()z
            .HasMany(c => c.BankAccounts)
            .WithOne(b => b.Customer)
            .HasForeignKey(b => b.CustomerId);
       */
        base.OnModelCreating(modelBuilder);
    }

}
