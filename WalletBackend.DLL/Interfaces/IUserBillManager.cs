using WalletBackend.Data.Models.Bills;
using WalletBackend.Domain.Dtos.Bills;

namespace WalletBackend.Services.Interfaces
{
    public interface IUserBillManager
    {
        Task<int> AddAsync(UserBillDto dto);
        Task<UserBills> GetUserBillByIds(Guid billId, Guid userId);
    }
}
