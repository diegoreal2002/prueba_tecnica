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

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionCommand command)
    {
        var result = await _mediator.Send(command);
        if (result) return Ok("Transaction processed successfully.");
        return BadRequest("Failed to process transaction.");
    }

    [HttpGet("{bankAccountId}")]
    public async Task<IActionResult> GetTransactions(int bankAccountId)
    {
        var query = new GetTransactionsQuery { BankAccountId = bankAccountId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
