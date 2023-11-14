using Microsoft.EntityFrameworkCore;
using WalletBackend.Data;

namespace WalletBackend.API.Extensions
{
    public static class ProviderExtensions
    {
        public static void UseMigrations(this IServiceProvider provider)
        {
            var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
