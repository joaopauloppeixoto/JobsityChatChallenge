using AutoMapper;
using JobsityApi.Models;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Services.Interfaces;
using JobsityApi.Utils.CustomExceptions;
using JobsityApi.ViewModels;

namespace JobsityApi.Services;

public class MessageService : IMessageService
{
    public IMapper _mapper { get; set; }
    public IMessageRepository _repository { get; set; }
    public IUserRepository _userRepository { get; set; }
    public IChatroomRepository _chatroomRepository { get; set; }
    public MessageService(
        IMapper mapper,
        IMessageRepository messageRepository,
        IUserRepository userRepository,
        IChatroomRepository chatroomRepository
    ) {
        _mapper = mapper;
        _repository = messageRepository;
        _userRepository = userRepository;
        _chatroomRepository = chatroomRepository;
    }

    public async Task<IList<MessageViewModel>> GetByChatroomAsync(string chatroomTitle)
    {
        return (await _repository.GetByChatroomAsync(chatroomTitle))
            .Select(w => _mapper.Map<Message, MessageViewModel>(w))
            .ToList();
    }

    public async Task PostAsync(NewMessageViewModel message, string normalizedUserName)
    {
        var newMessage = _mapper.Map<NewMessageViewModel, Message>(message);
        var sender = await _userRepository.GetByUsernameAsync(normalizedUserName);
        var chatroom = await _chatroomRepository.GetByTitleAsync(message.ChatroomTitle);

        if (sender == null) throw new InvalidUserException();
        if (chatroom == null) throw new InvalidChatroomException();

        newMessage.Sender = sender;
        newMessage.SourceChatroom = chatroom;

        await _repository.PostAsync(newMessage);
    }
}
