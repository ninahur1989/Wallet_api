using Wallet_App.Data.Enums;

namespace Wallet_App.Data.Models
{
    public class Transaction
    {
        public ulong Id { get; set; }
        public decimal Sum { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }

        public Account? AuthorizedUser { get; set; }
        public uint? AuthorizedUserId { get; set; }

        public Card? CardFrom { get; set; }
        public uint? CardFromId { get; set; }

        public Card? CardTo { get; set; }
        public uint? CardToId { get; set; }
    }
}
