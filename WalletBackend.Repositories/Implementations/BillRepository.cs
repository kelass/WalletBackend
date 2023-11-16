using WalletBackend.Data;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Repositories.Interfaces;

namespace WalletBackend.Repositories.Implementations
{
    public class BillRepository:Repository<Bill, ApplicationDbContext>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
