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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionCommand dto)
    {
        // Crear un comando con los datos del body y el ID
        var command = new UpdateTransactionCommand
        {
            TransactionId = id,
            Description = dto.Description
        };

        var result = await _mediator.Send(command);
        if (!result)
            return NotFound("Transaction not found or update failed.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var result = await _mediator.Send(new DeleteTransactionCommand { TransactionId = id });
        if (!result)
            
            return Conflict("The transaction cannot be deleted because it has related records.");

        return NoContent();
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] CreateTransactionCommand command)
    {
        // Asignar automáticamente el tipo de transacción
        command.TransactionType = "Withdrawal";

        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Insufficient funds or invalid account.");

        return Ok("Withdrawal completed successfully.");
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] CreateTransactionCommand command)
    {
        // Validar que el monto sea mayor a 0
        if (command.Amount <= 0)
            return BadRequest("The deposit amount must be greater than 0.");

        // Asignar automáticamente el tipo de transacción
        command.TransactionType = "Deposit";

        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Failed to process the deposit.");

        return Ok("Deposit completed successfully.");
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferTransactionCommand command)
    {

        if (command.Amount <= 0)
            return BadRequest("The transfer amount must be greater than 0.");

        var result = await _mediator.Send(command);
        if (!result)
            return BadRequest("Transfer failed. Insufficient funds or invalid accounts.");

        // Asignar automáticamente el tipo de transacción
        command.TransactionType = "Transfer";

        return Ok("Transfer completed successfully.");
    }
}
