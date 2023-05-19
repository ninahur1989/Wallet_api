namespace Wallet_App.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context?.Database.EnsureCreated();

                if (!context.Accounts.Any())
                {
                    context.Accounts.Add(new Models.Account());
                    context.Accounts.Add(new Models.Account());
                    context.Accounts.Add(new Models.Account() { Name = "Stanislav" });
                    context.SaveChanges();
                }
                if (!context.Cards.Any())
                {
                    context.Cards.Add(new Models.Card() { AccountId = 1, Balance = 120, BalanceLimit = 1500, Name = "Card1" });
                    context.Cards.Add(new Models.Card() { AccountId = 1, Balance = 490, BalanceLimit = 1500, Name = "Card2" });
                    context.SaveChanges();
                }
                if (!context.Transactions.Any())
                {
                    context.Transactions.AddRange(new Models.Transaction()
                    {
                        Id = 1,
                        AuthorizedUserId = 3,
                        CreatedAt = DateTime.UtcNow,
                        CardFromId = 1,
                        CardToId = 2,
                        Status = Enums.TransactionStatus.Pending,
                        Sum = 100,
                        Type = Enums.TransactionType.Payment
                    },
                    new Models.Transaction()
                    {
                        Id = 2,
                        AuthorizedUserId = 2,
                        CreatedAt = DateTime.UtcNow,
                        CardFromId = 2,
                        CardToId = 1,
                        Status = Enums.TransactionStatus.Failed,
                        Sum = 132,
                        Type = Enums.TransactionType.Payment
                    },
                    new Models.Transaction()
                    {
                        Id = 3,
                        AuthorizedUserId = 2,
                        CreatedAt = DateTime.UtcNow,
                        CardFromId = 2,
                        CardToId = 1,
                        Status = Enums.TransactionStatus.Failed,
                        Sum = 422,
                        Type = Enums.TransactionType.Payment
                    },
                    new Models.Transaction()
                    {
                        Id = 4,
                        AuthorizedUserId = 3,
                        CreatedAt = DateTime.UtcNow,
                        CardFromId = 1,
                        CardToId = 2,
                        Status = Enums.TransactionStatus.Success,
                        Sum = 555,
                        Type = Enums.TransactionType.Credit
                    },
                    new Models.Transaction()
                    {
                        Id = 5,
                        AuthorizedUserId = 1,
                        CreatedAt = DateTime.UtcNow,
                        CardFromId = 1,
                        CardToId = 2,
                        Status = Enums.TransactionStatus.Success,
                        Sum = 555,
                        Type = Enums.TransactionType.Credit
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
