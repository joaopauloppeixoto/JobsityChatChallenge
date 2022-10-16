using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<IdentityUser> CheckAsync(IdentityUser user);
    public Task<IdentityUser> RegisterAsync(IdentityUser user);
    public Task<IdentityUser?> GetByUsernameAsync(string username);
}
