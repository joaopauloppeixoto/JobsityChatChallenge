using JobsityApi.Repositories.Interfaces;
using JobsityApi.Services.Interfaces;
using JobsityApi.Services;
using Microsoft.EntityFrameworkCore;

namespace JobsityApi.Data;

public static class DbContextDependency
{
    public static void RegisterDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
}
