using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;

namespace Scan2Dine.EntityModels;

public static class OsDbContextExtensions
{
    public static IServiceCollection AddOsDbContext(
        this IServiceCollection services,
        string connectionString = "server=127.0.0.1;uid=root;pwd=root;database=os_db")
    {
        services.AddDbContext<OsDbContext>(options =>
        {
            options.UseMySQL(connectionString);
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);

        return services;
    }
}