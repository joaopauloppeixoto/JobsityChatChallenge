using JobsityApi.Data;
using JobsityApi.Models;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Utils.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<IdentityUser, IdentityRole>(u =>
        {
            u.Password.RequireNonAlphanumeric = false;
            u.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    }
}
