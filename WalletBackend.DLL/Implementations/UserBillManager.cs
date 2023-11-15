using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Domain.Dtos.Bills;
using WalletBackend.Repositories.Interfaces;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.Services.Implementations
{
    public class UserBillManager:IUserBillManager
    {
        private readonly IUserBillRepository _userBillRepository;
        public UserBillManager(IUserBillRepository userBillReposiotry)
        {
            _userBillRepository = userBillReposiotry;
        }

        public async Task<int> AddAsync(UserBillDto dto)
        => await _userBillRepository.AddAsync(new UserBills { BillId = dto.BillId, UserId = dto.UserId});

        public async Task<UserBills> GetUserBillByIds(Guid billId, Guid userId)
            => await _userBillRepository.GetAll().FirstOrDefaultAsync(ub=>ub.UserId == userId && ub.BillId == billId);
    }
}
