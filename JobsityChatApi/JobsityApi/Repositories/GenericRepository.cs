using AutoMapper;
using JobsityApi.Data;
using JobsityApi.Models;
using JobsityApi.Utils.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace JobsityApi.Repositories;

public class GenericRepository<T>
    where T : IdentityModel
{
    public ApplicationDbContext Context { get; set; }
    public GenericRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<IList<T>> GetAll()
    {
        return await Context.Set<T>().ToListAsync();
    }
    public async Task<T> GetById(Guid Id)
    {
        var result = await Context.Set<T>().FirstOrDefaultAsync(w => w.Id == Id);

        if (result == null)
            throw new IdNotFoundException();

        return result;
    }
}
