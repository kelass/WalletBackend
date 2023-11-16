using WalletBackend.Data.Models.Bills;
using WalletBackend.Domain.Dtos.Bills;

namespace WalletBackend.Services.Interfaces
{
    public interface IBillManager
    {
        Task<int> CreateAsync(BillDto entity);
        Task<Bill> GetById(Guid id);
    }
}
