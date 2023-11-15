using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletBackend.Data.Models.Bills;

namespace WalletBackend.Data.Configurations.Bills
{
    public class BillsConfiguration : DefaultEntityConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
        }
    }
}
