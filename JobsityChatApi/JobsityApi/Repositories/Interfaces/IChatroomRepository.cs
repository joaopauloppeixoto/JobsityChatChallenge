using JobsityApi.Models;

namespace JobsityApi.Repositories.Interfaces;

public interface IChatroomRepository
{
    public Task<IList<Chatroom>> GetAllAsync();
    public Task<Chatroom?> GetByTitleAsync(string title);
}
