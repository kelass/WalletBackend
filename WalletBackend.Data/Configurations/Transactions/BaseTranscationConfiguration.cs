using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletBackend.Domain.Models.Transactions;

namespace WalletBackend.Data.Configurations.Transactions
{
    public class BaseTranscationConfiguration:DefaultEntityConfiguration<BaseTransaction>
    {
        public override void Configure(EntityTypeBuilder<BaseTransaction> builder)
        {
            base.Configure(builder);
        }
    }
}
