using Wallet_App.Data.Models;

namespace Wallet_App.Data.Services
{
    public interface ICardService
    {
        public Task<Card> GetCard(uint accountId);
    }
}
