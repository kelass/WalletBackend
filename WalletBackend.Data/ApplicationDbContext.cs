using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Configurations.Bills;
using WalletBackend.Data.Configurations.Transactions;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Models.Transactions;

namespace WalletBackend.Data
{
    public class ApplicationDbContext:IdentityDbContext<WalletUser,WalletRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<WalletUser> Users { get; set; }
        public DbSet<WalletRole> Roles { get; set; }
        public DbSet<AuthorizeTransaction> AuthorizeTransactions { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<UserBills> UserBills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AuthorizeTranscationConfiguration());
            builder.ApplyConfiguration(new BillsConfiguration());
            builder.ApplyConfiguration(new UserBillsConfiguration());
        }
    }
}