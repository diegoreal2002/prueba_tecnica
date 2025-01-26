using MediatR;

public class TransferTransactionCommand : IRequest<bool>
{
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public decimal Amount { get; set; }
    public string? TransactionType { get; set; }
}