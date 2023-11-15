using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Models.Transactions;
using WalletBackend.Repositories.Interfaces;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.Services.Implementations
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionRepository _repository;
        private readonly UserManager<WalletUser> _userManager;
        public TransactionManager(ITransactionRepository repository, UserManager<WalletUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<AuthorizeTransaction>> GetUserTransactions(Guid id)
        =>await _repository.GetAll().Where(t => t.UserId == id).OrderBy(t => t.CreatedDate == DateTime.UtcNow).Take(10).ToListAsync();
    }
}
