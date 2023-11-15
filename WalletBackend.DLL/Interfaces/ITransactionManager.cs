using WalletBackend.Domain.Dtos.Transactions;
using WalletBackend.Domain.Models.Transactions;

namespace WalletBackend.Services.Interfaces
{
    public interface ITransactionManager
    {
        Task<IEnumerable<AuthorizeTransaction>> GetTransactions(Guid id, int count);
        Task<int> AddTransaction(AuthorizeTransactionDto dto);
    }
}
