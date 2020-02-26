using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodayList.Application.Common.Interfaces;
using TodayList.Infrastructure.Persistence;

namespace TodayList.Api.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodayListDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(TodayListDbContext).Assembly.FullName));
            });

            services.AddScoped<ITodayListDbContext>(provider => provider.GetService<TodayListDbContext>());
            
            return services;
        }
    }
}