using Microsoft.AspNetCore.Mvc;
using Wallet_App.Data.Services;
using NuGet.Protocol;

namespace Wallet_App.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService? _accountService;
        private readonly IPointsService? _pointstService;

        public AccountController(IAccountService accountService, IPointsService pointsService)
        {
            _accountService = accountService;
            _pointstService = pointsService;
        }

        [HttpGet("{id}/card/balance")]
        public IActionResult CardBalance(uint id)
        {
            try
            {
                return Ok(_accountService?.AccountCardBalance(id).ToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToJson());
            }
        }

        [HttpGet("{id}/card/balance/limit")]
        public IActionResult BalanceLimit(uint id)
        {
            try
            {
                return Ok(_accountService?.AccountCardBalanceLimit(id).ToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/dailypoints")]
        public IActionResult DailyPoints(uint id)
        {
            try
            {
                return Ok(_pointstService.GetDaypoints());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/nopaymentdue")]
        public IActionResult NoPaymentDue()
        {
            return Ok(DateTime.Now.ToString("MMMM"));
        }
    }
}
