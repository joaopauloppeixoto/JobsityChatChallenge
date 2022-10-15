using JobsityApi.ViewModels;

namespace JobsityApi.Repositories.Interfaces;

public interface IAuthService
{
    public Task RegisterUserAsync(NewUserViewModel newUser);
}
