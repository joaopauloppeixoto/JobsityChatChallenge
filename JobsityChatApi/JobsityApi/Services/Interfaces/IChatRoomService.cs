using JobsityApi.ViewModels;

namespace JobsityApi.Services.Interfaces;

public interface IChatroomService
{
    public Task<IList<ChatroomViewModel>> GetAll();
}
