using Microsoft.EntityFrameworkCore;
using Wallet_App.Data.Models;

namespace Wallet_App.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        private readonly ICardService? _cardService;

        public AccountService(ICardService cardService, AppDbContext context)
        {
            _cardService = cardService;
            _context = context;
        }

        public decimal AccountCardBalance(uint id)
        {
            var res = AccountCard(id);
            return res.Result.Balance;
        }

        public decimal AccountCardBalanceLimit(uint id)
        {
            var res = AccountCard(id);
            return res.Result.BalanceLimit;
        }

        public async Task<Card> AccountCard(uint id)
        {
            var res = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id) == null ? null :
                       await _cardService.GetCard(id);

            return res;
        }
    }
}
