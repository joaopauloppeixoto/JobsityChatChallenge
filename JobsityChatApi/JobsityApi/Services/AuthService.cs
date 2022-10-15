using AutoMapper;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Services;

public class AuthService : IAuthService
{
    public IMapper Mapper { get; set; }
    public AuthService(IMapper mapper)
    {
        Mapper = mapper;
    }

    public Task RegisterUserAsync(NewUserViewModel newUser)
    {
        var user = Mapper.Map<NewUserViewModel, IdentityUser>(newUser);
        throw new NotImplementedException();
    }
}
