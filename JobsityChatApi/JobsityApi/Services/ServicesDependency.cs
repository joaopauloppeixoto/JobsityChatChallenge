using JobsityApi.Repositories.Interfaces;
using JobsityApi.Services.Interfaces;

namespace JobsityApi.Services;

public static class ServicesDependency
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IChatroomService, ChatroomService>();
        services.AddScoped<IMessageService, MessageService>();
    }
}
