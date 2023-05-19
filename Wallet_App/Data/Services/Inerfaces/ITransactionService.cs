using Wallet_App.Data.ViewModel;

namespace Wallet_App.Data.Services
{
    public interface ITransactionService
    {
        public Task<TransactionDetailsVM?> TransactionDetails(uint transactionId, uint userId);

        public Task<List<TransactionListVM>> GetTransactionsByUser(uint userId, ushort transactionCount);
    }
}
