using JobsityApi.Repositories.Interfaces;

namespace JobsityApi.Services;

public static class ServicesDependency
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
    }
}
