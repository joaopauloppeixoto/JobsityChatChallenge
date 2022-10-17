using JobsityApi.Models;
using JobsityApi.Utils.AutoMapperProfiles;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace JobsityApi.Data.Seeds;

public class IdentityUserSeed : Seed<IdentityUser>
{
    public override IList<IdentityUser> Get()
    {
        var hash = new Hash(SHA512.Create());
        return new List<IdentityUser>() {
            new IdentityUser("FinancialBot") {
                NormalizedUserName = "FinancialBot".ToUpper(),
                Email = "FinancialBot",
                NormalizedEmail = "FinancialBot".ToUpper(),
                PasswordHash = hash.PasswordHash("BotFinancialSecret"),
            }
        };
    }
}
