using AutoMapper;
using JobsityApi.Models;
using JobsityApi.Repositories;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Services.Interfaces;
using JobsityApi.ViewModels;

namespace JobsityApi.Services;

public class ChatroomService : GenericService<Chatroom, ChatroomViewModel>, IChatroomService
{
    public ChatroomService(IMapper mapper, IChatroomRepository repository) : base(mapper, (ChatroomRepository) repository)
    {
    }
}
