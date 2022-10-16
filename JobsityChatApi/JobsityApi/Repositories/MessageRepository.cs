using JobsityApi.Data;
using JobsityApi.Models;
using JobsityApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobsityApi.Repositories;

public class MessageRepository : IMessageRepository
{
    public ApplicationDbContext Context { get; set; }
    public MessageRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<IList<Message>> GetByChatroomAsync(string chatroomTitle)
    {
        return await Context.Messages
            .Include(m => m.SourceChatroom)
            .Where(m => m.SourceChatroom.Title == chatroomTitle)
            .OrderByDescending(w => w.CreatedOn)
            .Take(50)
            .OrderBy(w => w.CreatedOn)
            .Include(m => m.Sender)
            .ToListAsync();
    }

    public async Task PostAsync(Message message)
    {
        await Context.Messages.AddAsync(message);
        await Context.SaveChangesAsync();
    }
}
