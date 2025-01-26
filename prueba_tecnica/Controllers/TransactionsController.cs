using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBankingApp.Application.Commands.Transactions;
using MyBankingApp.Application.Queries.Transactions;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{bankAccountId}")]
    public async Task<IActionResult> GetTransactions(int bankAccountId)
    {
        var query = new GetTransactionsQuery { BankAccountId = bankAccountId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] CreateTransactionCommand command)
    {
        if (command.TransactionType != "Withdrawal")
            return BadRequest("TransactionType must be 'Withdrawal'.");

        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Insufficient funds or invalid account.");

        return Ok("Withdrawal completed successfully.");
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] CreateTransactionCommand command)
    {
        if (command.TransactionType != "Deposit")
            return BadRequest("TransactionType must be 'Deposit'.");

        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Failed to process deposit.");

        return Ok("Deposit completed successfully.");
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferTransactionCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Transfer failed. Insufficient funds or invalid accounts.");

        return Ok("Transfer completed successfully.");
    }
}
