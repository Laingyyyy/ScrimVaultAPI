using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Models.Team.Repository;

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
        
        // adding repositories to services
        services.AddScoped<ITeamRepository, TeamRepository>();
        
        return services;
    }
}