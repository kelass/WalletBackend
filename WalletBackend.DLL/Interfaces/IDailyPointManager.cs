using WalletBackend.Data.Models.DailyPoints;

namespace WalletBackend.Services.Interfaces
{
    public interface IDailyPointManager
    {
        Task SetDailyPoint(Guid userId);
        Task<IEnumerable<DailyPoint>> GetAll();
        Task<int> AddAsync(Guid userId, decimal points);
        Task<decimal> GetPointsByUserId(Guid userId);
    }
}
