using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Services;

public static class PersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        // adding database to the service container
        services.AddDbContext<ApiContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("ApiDatabase"));
        });
        
        
        
        return services;
    }
}