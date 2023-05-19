using Wallet_App.Data.Models;

namespace Wallet_App.Data.Services
{
    public interface IAccountService
    {
        public Task<Card> AccountCard(uint id);
        public decimal AccountCardBalance(uint id);
        public decimal AccountCardBalanceLimit(uint id);
    }
}
