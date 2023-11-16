using WalletBackend.Data;
using WalletBackend.Data.Models.DailyPoints;
using WalletBackend.Repositories.Interfaces;

namespace WalletBackend.Repositories.Implementations
{
    public class DailyPointRepository:Repository<DailyPoint, ApplicationDbContext>, IDailyPointRepository
    {
        public DailyPointRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
