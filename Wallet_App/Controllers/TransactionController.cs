using Microsoft.AspNetCore.Mvc;
using Wallet_App.Data.Services;
using NuGet.Protocol;

namespace Wallet_App.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService? _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("api/transactions")]
        public async Task<IActionResult> Transactions(uint userId, ushort transactionCount = 10)
        {
            try
            {
                return Ok(await _transactionService.GetTransactionsByUser(userId, transactionCount));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToJson());
            }
        }

        [HttpGet("api/transaction/{id}")]
        public async Task<IActionResult> TransactionDetails(uint id, uint userId)
        {
            try
            {
                return Ok(await _transactionService.TransactionDetails(id, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
