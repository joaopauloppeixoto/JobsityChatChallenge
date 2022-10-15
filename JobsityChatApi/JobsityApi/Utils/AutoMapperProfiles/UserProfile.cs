using AutoMapper;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Utils.AutoMapperProfiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<NewUserViewModel, IdentityUser>()
            .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                );
	}
}
