using JobsityApi.Models;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Data.Seeds;

public class IdentityUserSeed : Seed<IdentityUser>
{
    public override IList<IdentityUser> Get() => new List<IdentityUser>() {
        new IdentityUser("FinancialBot")
        {
            NormalizedUserName = "FinancialBot".ToUpper(),
        },
    };
}
