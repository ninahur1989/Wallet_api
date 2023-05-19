using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Wallet_App.Data.ViewModel;

namespace Wallet_App.Data.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionDetailsVM?> TransactionDetails(uint transactionId, uint userId)
        {
            var resTransaction = await _context.Transactions.Where(x => x.Id == transactionId
                && (x.CardFrom.AccountId == userId
                || x.CardTo.AccountId == userId
                || x.AuthorizedUserId == userId))
                .Include(x => x.CardFrom)
                .Include(x => x.CardTo)
                .Include(x => x.AuthorizedUser)
                .FirstOrDefaultAsync();
            return resTransaction == null ? null : new TransactionDetailsVM()
            {
                CardName = resTransaction.CardToId != resTransaction.AuthorizedUserId
                        ? resTransaction.CardFrom.Name : resTransaction.CardTo.Name,
                AuthorizedUserName = resTransaction.AuthorizedUserId != resTransaction.CardFromId
                            ? resTransaction.AuthorizedUser.Name
                            : null,
                Description = resTransaction.Description,
                Name = resTransaction.Name,
                CreatedAt = resTransaction.CreatedAt.ToString("MM/dd/yyyy h:mm tt"),
                Status = resTransaction.Status,
                Sum = resTransaction.Sum,
                Type = resTransaction.Type
            };
        }

        public async Task<List<TransactionListVM>> GetTransactionsByUser(uint userId, ushort transactionCount)
        {
            var resTransactions = await _context.Transactions.Where(x => x.CardFrom.AccountId == userId || x.CardTo.AccountId == userId)
                                 .OrderBy(x => x.CreatedAt)
                                 .Take(transactionCount)
                                 .Include(x => x.CardFrom)
                                 .Include(x => x.CardTo)
                                 .Include(x => x.AuthorizedUser)
                                 .AsNoTracking().ToListAsync();

            var transactionListVM = new List<TransactionListVM>(resTransactions.Count);

            foreach (var resTransaction in resTransactions)
            {
                transactionListVM.Add(new TransactionListVM()
                {
                    Id = resTransaction.Id,
                    CardName = resTransaction.CardToId != resTransaction.AuthorizedUserId
                        ? resTransaction.CardFrom.Name : resTransaction.CardTo.Name,
                    AuthorizedUserName = resTransaction.AuthorizedUserId != resTransaction.CardFromId
                            ? resTransaction.AuthorizedUser.Name
                            : null,
                    Description = resTransaction.Description,
                    Name = resTransaction.Name,
                    CreatedAt = resTransaction.CreatedAt.ToString("MM/dd/yyyy"),
                    CreatedAtFull = (DateTime.Now - resTransaction.CreatedAt).Days < 7 ? resTransaction.CreatedAt.ToString("dddd") : null,
                    Status = resTransaction.Status,
                    Sum = (uint)resTransaction.Sum,
                    Type = resTransaction.Type,
                    Icon = SystemIcons.Warning.ToBitmap()
                });
            }

            return transactionListVM;
        }
    }
}
