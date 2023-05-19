namespace Wallet_App.Data.Models
{
    public class Card
    {
        public uint Id { get; set; } 
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceLimit { get; set; }
        public Account Account { get; set; }
        public uint AccountId { get; set; }
    }
}
