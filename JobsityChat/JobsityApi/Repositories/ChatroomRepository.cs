using JobsityApi.Data;
using JobsityApi.Models;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Utils.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace JobsityApi.Repositories;

public class ChatroomRepository : IChatroomRepository
{
    public ApplicationDbContext Context { get; set; }
    public ChatroomRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<IList<Chatroom>> GetAllAsync()
    {
        return await Context.Chatrooms
            .OrderBy(w => w.Topic)
            .ThenBy(c => c.Title)
            .ToListAsync();
    }

    public async Task<Chatroom?> GetByTitleAsync(string title)
    {
        return await Context.Chatrooms
            .SingleOrDefaultAsync(c => c.Title == title);
    }
}
