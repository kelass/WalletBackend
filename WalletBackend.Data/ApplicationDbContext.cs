using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<BaseTransaction> Transactions { get; set; }
        public DbSet<AuthorizeTransaction> AuthorizeTransactions { get; set; }
    }
}