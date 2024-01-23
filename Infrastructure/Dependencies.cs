using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration config, IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(c =>
                c.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            /*services.AddDbContext<IdentityDbContext>(c =>
                           c.UseNpgsql(config.GetConnectionString("IdentityConnection")));*/
        }
    }
}
