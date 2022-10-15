using JobsityApi.Repositories;
using JobsityApi.Repositories.Interfaces;

namespace JobsityApi.Services;

public static class RepositoriesDependency
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IChatroomRepository, ChatroomRepository>();
    }
}
