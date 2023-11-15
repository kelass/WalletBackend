using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models;
using WalletBackend.Data.Models.Identity;

namespace WalletBackend.Data.Configurations.DailyPoints
{
    public class DailyPointConfiguration:DefaultEntityConfiguration<DailyPoint>
    {
        public override void Configure(EntityTypeBuilder<DailyPoint> builder)
        {
            builder.HasIndex(i => new { i.UserId });
            builder.HasOne<WalletUser>().WithMany().HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
