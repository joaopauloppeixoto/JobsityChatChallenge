using JobsityApi.Models;

namespace JobsityApi.Data.Seeds;

public abstract class Seed<T>
{
    public abstract IList<T> Get();
}