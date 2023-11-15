using WalletBackend.Data;
using WalletBackend.Domain.Models.Transactions;
using WalletBackend.Repositories.Interfaces;

namespace WalletBackend.Repositories.Implementations
{
    public class TransactionRepository:Repository<AuthorizeTransaction, ApplicationDbContext>, ITransactionRepository
    {
    }
}
