using AutoMapper;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Services;

public class AuthService : IAuthService
{
    public IMapper Mapper { get; set; }
    public IUserRepository UserRepository { get; set; }
    public TokenService TokenService { get; set; }
    public AuthService(IMapper mapper, IUserRepository userRepository, TokenService tokenService)
    {
        Mapper = mapper;
        UserRepository = userRepository;
        TokenService = tokenService;
    }

    public async Task<UserViewModel> RegisterUserAsync(NewUserViewModel newUser)
    {
        var user = Mapper.Map<NewUserViewModel, IdentityUser>(newUser);

        return Mapper.Map<IdentityUser, UserViewModel>(await UserRepository.RegisterAsync(user));
    }

    public async Task<UserViewModel> AuthAsync(AuthViewModel authViewModel)
    {
        var user = Mapper.Map<AuthViewModel, IdentityUser>(authViewModel);

        var checkedUser = await UserRepository.CheckAsync(user);

        var auth = Mapper.Map<IdentityUser, UserViewModel>(checkedUser);
        auth.Token = TokenService.GenerateToken(checkedUser);

        return auth;
    }
}
