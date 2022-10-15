using JobsityApi.Data;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Utils.CustomExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobsityApi.Repositories;

public class UserRepository : IUserRepository
{
    public ApplicationDbContext Context { get; set; }
    public UserRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<IdentityUser> RegisterAsync(IdentityUser user)
    {
        var newUser = await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();

        return newUser.Entity;
    }

    public async Task<IdentityUser> CheckAsync(IdentityUser identityUser)
    {
        var user = await Context.Users.SingleOrDefaultAsync(
            u => u.NormalizedEmail == identityUser.NormalizedEmail
            && u.PasswordHash == identityUser.PasswordHash
        );

        if (user == null)
            throw new InvalidLoginOrPasswordException();

        return user;
    }
}
