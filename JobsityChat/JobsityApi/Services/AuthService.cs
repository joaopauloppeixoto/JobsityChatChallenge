using AutoMapper;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Services;

public class AuthService : IAuthService
{
    public IMapper _mapper { get; set; }
    public IUserRepository _repository { get; set; }
    public TokenService TokenService { get; set; }
    public AuthService(IMapper mapper, IUserRepository repository, TokenService tokenService)
    {
        _mapper = mapper;
        _repository = repository;
        TokenService = tokenService;
    }

    public async Task<UserViewModel> RegisterUserAsync(NewUserViewModel newUser)
    {
        var user = _mapper.Map<NewUserViewModel, IdentityUser>(newUser);

        return _mapper.Map<IdentityUser, UserViewModel>(await _repository.RegisterAsync(user));
    }

    public async Task<UserViewModel> AuthAsync(AuthViewModel authViewModel)
    {
        var user = _mapper.Map<AuthViewModel, IdentityUser>(authViewModel);

        var checkedUser = await _repository.CheckAsync(user);

        var auth = _mapper.Map<IdentityUser, UserViewModel>(checkedUser);
        auth.Token = TokenService.GenerateToken(checkedUser);

        return auth;
    }
}
