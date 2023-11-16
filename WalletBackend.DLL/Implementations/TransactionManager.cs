using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Dtos.Transactions;
using WalletBackend.Domain.Models.Transactions;
using WalletBackend.Repositories.Interfaces;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.Services.Implementations
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionRepository _repository;
        private readonly IBillManager _billManager;
        private readonly UserManager<WalletUser> _userManager;
        private decimal balance = 0;
        public TransactionManager(ITransactionRepository repository, IBillManager billManager)
        {
            _repository = repository;
            _billManager = billManager;
        }

        public async Task<IEnumerable<AuthorizeTransaction>> GetTransactions(Guid id, int count)
        => await _repository.GetAll().Where(t => t.BillId == id).OrderBy(t => t.CreatedDate == DateTime.UtcNow).Take(count).ToListAsync();

        public async Task<int> AddTransaction(AuthorizeTransactionDto dto)
        {
            IEnumerable<AuthorizeTransaction> transactions = await _repository.GetAll().Where(t => t.CreatedDate <= DateTime.UtcNow && t.BillId == dto.BillId).ToListAsync();
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
            }

            if (balance + dto.Amount <= 1500)
            {
                if (await _billManager.GetById(dto.BillId) != null)
                    return await _repository.AddAsync(new AuthorizeTransaction
                    {
                        Amount = dto.Amount,
                        CreatedDate = dto.CreatedDate,
                        Description = dto.Description,
                        Name = dto.Name,
                        Status = dto.Status,
                        Type = dto.Type,
                        UserId = dto.UserId,
                        BillId = dto.BillId
                    });
            }
            return 0;
        }
    }
}
