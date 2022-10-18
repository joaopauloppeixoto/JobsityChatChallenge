using JobsityApi.Models;
using JobsityApi.ViewModels;

namespace JobsityApi.Repositories.Interfaces;

public interface IMessageRepository
{
    public Task<IList<Message>> GetByChatroomAsync(string chatroomTitle);
    public Task PostAsync(Message message);
}
