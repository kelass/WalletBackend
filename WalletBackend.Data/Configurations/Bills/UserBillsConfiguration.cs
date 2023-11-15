using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Data.Models.Identity;

namespace WalletBackend.Data.Configurations.Bills
{
    public class UserBillsConfiguration : DefaultEntityConfiguration<UserBills>
    {
        public override void Configure(EntityTypeBuilder<UserBills> builder)
        {
            builder.HasIndex(i => new { i.UserId });
            builder.HasIndex(i => new { i.BillId });
            builder.HasOne<WalletUser>().WithMany().HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<Bill>().WithMany().HasForeignKey(t => t.BillId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
