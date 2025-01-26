using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyBankingApp.Application.Commands.Transactions;
using MyBankingApp.Application.Interfaces;
using MyBankingApp.Domain.Entities;

namespace MyBankingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountsController(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _bankAccountRepository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _bankAccountRepository.GetByIdAsync(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankAccount account)
        {
            await _bankAccountRepository.AddAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = account.BankAccountId }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BankAccount updatedAccount)
        {
            var account = await _bankAccountRepository.GetByIdAsync(id);
            if (account == null)
                return NotFound();

            account.AccountNumber = updatedAccount.AccountNumber;
            account.Balance = updatedAccount.Balance;

            await _bankAccountRepository.UpdateAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _bankAccountRepository.GetByIdAsync(id);
            if (account == null)
                return NotFound();


            await _bankAccountRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
