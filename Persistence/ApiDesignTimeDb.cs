using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence;

public class ApiDesignTimeDb : IDesignTimeDbContextFactory<ApiContext>
{
    public ApiContext CreateDbContext(string[] args)
    {
        const string conn = "Host=localhost;Port=5432;Username=ScrimVault;Password=Fr@nkie19!;Database=ScrimVaultDb";

        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseNpgsql(conn)
            .Options;
        
        return new ApiContext(options);
    }
}