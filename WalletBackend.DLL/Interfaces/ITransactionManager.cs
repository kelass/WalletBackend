using WalletBackend.Domain.Models.Transactions;

namespace WalletBackend.Services.Interfaces
{
    public interface ITransactionManager
    {
        Task<IEnumerable<AuthorizeTransaction>> GetUserTransactions(Guid id);
    }
}
