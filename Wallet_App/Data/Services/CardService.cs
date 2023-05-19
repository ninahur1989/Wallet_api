using Microsoft.EntityFrameworkCore;
using Wallet_App.Data.Models;

namespace Wallet_App.Data.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;

        public CardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Card> GetCard(uint accountId)
        {
            return await _context.Cards.FirstOrDefaultAsync(x => x.AccountId == accountId);
        }
    }
}

