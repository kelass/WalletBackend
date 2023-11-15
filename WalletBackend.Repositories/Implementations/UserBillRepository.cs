using WalletBackend.Data;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Repositories.Interfaces;

namespace WalletBackend.Repositories.Implementations
{
    public class UserBillRepository:Repository<UserBills,ApplicationDbContext>, IUserBillRepository
    {
        public UserBillRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
