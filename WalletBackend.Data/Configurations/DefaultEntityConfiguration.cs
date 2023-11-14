using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletBackend.Data.Models;

namespace WalletBackend.Data.Configurations
{
    public class DefaultEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity:BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
            => builder.HasKey(e => e.Id);
    }
}
