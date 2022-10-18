using JobsityApi.ViewModels;

namespace JobsityApi.Repositories.Interfaces;

public interface IAuthService
{
    public Task<UserViewModel> RegisterUserAsync(NewUserViewModel newUser);

    public Task<UserViewModel> AuthAsync(AuthViewModel authViewModel);
}
