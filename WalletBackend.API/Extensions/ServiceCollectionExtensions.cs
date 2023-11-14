using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WalletBackend.Data;
using WalletBackend.Data.Models.Identity;

namespace WalletBackend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly("WalletBackend.Data")));
            return services;
        }

        public static IServiceCollection AddWalletIdentity(this IServiceCollection services)
        {
            services.AddIdentity<WalletUser, WalletRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 4;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
