using JobsityChatApi.Models;

namespace JobsityChatApi.Data.Seeds;

public abstract class Seed<T>
    where T : IdentityModel
{
    public abstract IList<T> Get();
}