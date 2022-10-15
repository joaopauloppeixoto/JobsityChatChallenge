using AutoMapper;
using JobsityApi.Models;
using JobsityApi.ViewModels;

namespace JobsityApi.Utils.AutoMapperProfiles;

public class ChatRoomProfile : Profile
{
	public ChatRoomProfile()
	{
        CreateMap<Chatroom, ChatroomViewModel>();
    }
}
