using Wallet_App.Data.Enums;

namespace Wallet_App.Data.ViewModel
{
    public class TransactionDetailsVM
    {
        public decimal Sum { get; set; }
        public string? Name { get; set; }
        public string? CardName { get; set; }
        public string? Description { get; set; }
        public string CreatedAt { get; set; }
        public string? AuthorizedUserName { get; set; }

        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
