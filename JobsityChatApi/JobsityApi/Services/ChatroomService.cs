using AutoMapper;
using JobsityApi.Models;
using JobsityApi.Repositories;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Services.Interfaces;
using JobsityApi.ViewModels;

namespace JobsityApi.Services;

public class ChatroomService : IChatroomService
{
    public IMapper _mapper { get; set; }
    public IChatroomRepository _repository { get; set; }
    public ChatroomService(IMapper mapper, IChatroomRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<ChatroomViewModel>> GetAll()
    {
        return (await _repository.GetAllAsync())
            .Select(w => _mapper.Map<Chatroom, ChatroomViewModel>(w))
            .ToList();
    }
}
