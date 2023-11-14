using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Models.Transactions;

namespace WalletBackend.Data.Configurations.Transactions
{
    public class AuthorizeTranscationConfiguration:DefaultEntityConfiguration<AuthorizeTransaction>
    {
        public override void Configure(EntityTypeBuilder<AuthorizeTransaction> builder)
        {
            builder.HasIndex(i => new { i.UserId });
            builder.HasOne<WalletUser>().WithMany().HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
