using AutoMapper;
using JobsityApi.Models;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Utils.AutoMapperProfiles;

public class MessageProfile : Profile
{
	public MessageProfile()
	{
        CreateMap<Message, MessageViewModel>();
        CreateMap<IdentityUser, SenderViewModel>()
            .ForPath(
                dest => dest.Nickname,
                opt => opt.MapFrom(src => src.UserName)
            );
        CreateMap<NewMessageViewModel, Message>()
            .ForPath(
                dest => dest.SourceChatroom.Title,
                opt => opt.MapFrom(src => src.ChatroomTitle)
            );
    }
}
