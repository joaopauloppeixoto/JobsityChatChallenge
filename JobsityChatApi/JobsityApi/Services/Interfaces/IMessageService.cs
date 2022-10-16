using JobsityApi.ViewModels;

namespace JobsityApi.Services.Interfaces;

public interface IMessageService
{
    public Task<IList<MessageViewModel>> GetByChatroomAsync(string chatroomTitle);
    public Task PostAsync(NewMessageViewModel message, string normalizedUserName);
}
